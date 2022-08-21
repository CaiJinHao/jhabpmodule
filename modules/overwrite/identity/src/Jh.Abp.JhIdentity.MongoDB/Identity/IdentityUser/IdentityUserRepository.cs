using Jh.Abp.JhIdentity.MongoDB;
using Jh.Abp.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;

namespace Jh.Abp.JhIdentity
{
	public class IdentityUserRepository : CrudRepository<IAbpIdentityMongoDbContext, Volo.Abp.Identity.IdentityUser, System.Guid>, IIdentityUserRepository
	{
        public IdentityUserRepository(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IJhIdentityMongoDbContext jhIdentityDbContext { get; set; }
		public IRepository<JhOrganizationUnit, Guid> _appRoleRepository { get; set; }
	

		public virtual async Task<List<Volo.Abp.Identity.IdentityRole>> GetRolesAsync(
			Guid id,
			bool includeDetails = false,
			CancellationToken cancellationToken = default)
		{
			var user = await GetAsync(id, cancellationToken: cancellationToken);
			var userRoleIds = user.Roles.Select(a=>a.RoleId).ToArray();
			return await (await GetMongoQueryableAsync<IdentityRole>()).Where(a=> userRoleIds.Contains(a.Id))
				.ToListAsync();
		}

		public virtual async Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(
			Guid id,
			CancellationToken cancellationToken = default)
		{
			var user = await GetAsync(id,cancellationToken:cancellationToken);
			var userOrganizationUnitIds = user.OrganizationUnits.Select(a=>a.OrganizationUnitId).ToArray();
			//��ȡ�û�������֯
			return await (await GetMongoQueryableAsync<OrganizationUnit>()).Where(a => userOrganizationUnitIds.Contains(a.Id))
				.ToListAsync();
		}

		public virtual async Task<IdentityUser> GetSuperiorUserAsync(Guid id,CancellationToken cancellationToken = default)
		{
			var user = await GetAsync(id,cancellationToken:cancellationToken);
			var userOrganizationUnitId = user.OrganizationUnits.OrderByDescending(a => a.CreationTime).FirstOrDefault()?.OrganizationUnitId;
			//��ȡ�û�������֯
			var userOrg = await (await GetMongoQueryableAsync<OrganizationUnit>())
				.FirstOrDefaultAsync(a=>a.Id== userOrganizationUnitId);

            //��ȡ�����֯�ĸ�����
            var superiorUserId = userOrg.GetProperty<Guid?>(nameof(JhOrganizationUnit.LeaderId));
            if (superiorUserId.Equals(id))//����ʵ�����븺���˲����ʱ�������򷵻�null�����ò���
            {
                //��ǰ�û�����֯������ʱ����ȡ�ϼ���֯������
                if (userOrg.ParentId.HasValue)
                {
					var JhOrganizationUnits= jhIdentityDbContext.Collection<JhOrganizationUnit>().AsQueryable();
					var parentOrg = await JhOrganizationUnits.FirstOrDefaultAsync(a => a.Id == userOrg.ParentId, cancellationToken);
					superiorUserId = parentOrg.LeaderId;
					if (superiorUserId.Equals(Guid.Empty))
					{
						return default;//�Ҳ����ϼ��������ò��裬todo:û���ϼ��쵼��ʱ��ù�����������
					}
				}
            }
            if (superiorUserId.HasValue)
            {
				var data = await GetAsync(superiorUserId.Value, cancellationToken: cancellationToken);
				if (data != null)
				{
					return data;
				}
			}
            return default;
        }
	}
}
