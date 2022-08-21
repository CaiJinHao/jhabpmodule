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
			//获取用户所属组织
			return await (await GetMongoQueryableAsync<OrganizationUnit>()).Where(a => userOrganizationUnitIds.Contains(a.Id))
				.ToListAsync();
		}

		public virtual async Task<IdentityUser> GetSuperiorUserAsync(Guid id,CancellationToken cancellationToken = default)
		{
			var user = await GetAsync(id,cancellationToken:cancellationToken);
			var userOrganizationUnitId = user.OrganizationUnits.OrderByDescending(a => a.CreationTime).FirstOrDefault()?.OrganizationUnitId;
			//获取用户所属组织
			var userOrg = await (await GetMongoQueryableAsync<OrganizationUnit>())
				.FirstOrDefaultAsync(a=>a.Id== userOrganizationUnitId);

            //获取这个组织的负责人
            var superiorUserId = userOrg.GetProperty<Guid?>(nameof(JhOrganizationUnit.LeaderId));
            if (superiorUserId.Equals(id))//创建实例人与负责人不相等时处理，否则返回null跳过该步骤
            {
                //当前用户是组织负责人时，获取上级组织负责人
                if (userOrg.ParentId.HasValue)
                {
					var JhOrganizationUnits= jhIdentityDbContext.Collection<JhOrganizationUnit>().AsQueryable();
					var parentOrg = await JhOrganizationUnits.FirstOrDefaultAsync(a => a.Id == userOrg.ParentId, cancellationToken);
					superiorUserId = parentOrg.LeaderId;
					if (superiorUserId.Equals(Guid.Empty))
					{
						return default;//找不到上级，跳过该步骤，todo:没有上级领导的时候该工作流不成立
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
