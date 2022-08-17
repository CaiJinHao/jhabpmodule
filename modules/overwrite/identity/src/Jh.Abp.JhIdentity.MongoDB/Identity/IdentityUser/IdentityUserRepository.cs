using Jh.Abp.JhIdentity.MongoDB;
using Jh.Abp.MongoDB;
using Microsoft.EntityFrameworkCore;
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
			Guid userid,
			bool includeDetails = false,
			CancellationToken cancellationToken = default)
		{

			var query = from userRole in (await GetMongoQueryableAsync<IdentityUserRole>())
						join role in (await GetMongoQueryableAsync<IdentityRole>()) on userRole.RoleId equals role.Id
						where userRole.UserId == userid
						select role;

			return await query.ToListAsync(GetCancellationToken(cancellationToken));
		}

		public virtual async Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(
			Guid id,
			CancellationToken cancellationToken = default)
		{
			var IdentityUsers = await GetMongoQueryableAsync<IdentityUser>();
			var IdentityUserOrganizationUnits = await GetMongoQueryableAsync<IdentityUserOrganizationUnit>();
			var OrganizationUnits = await GetMongoQueryableAsync<OrganizationUnit>();

			//获取用户所属组织
			var query = from user in IdentityUsers
						join userOu in IdentityUserOrganizationUnits on user.Id equals userOu.UserId
								 join ou in OrganizationUnits on userOu.OrganizationUnitId equals ou.Id
								 where user.Id == id
							   select ou;

            return await query.ToListAsync(GetCancellationToken(cancellationToken));
		}

		public virtual async Task<IdentityUser> GetSuperiorUserAsync(Guid userId,CancellationToken cancellationToken = default)
		{
			var IdentityUsers = await GetMongoQueryableAsync<IdentityUser>();
			var IdentityUserOrganizationUnits = await GetMongoQueryableAsync<IdentityUserOrganizationUnit>();
			var OrganizationUnits = await GetMongoQueryableAsync<OrganizationUnit>();

			//获取用户所属组织
			var userOrg = await (from user in IdentityUsers
								 join userOu in IdentityUserOrganizationUnits on user.Id equals userOu.UserId
									join ou in OrganizationUnits on userOu.OrganizationUnitId equals ou.Id
                                    where user.Id == userId orderby userOu.CreationTime descending
                                    select ou).FirstOrDefaultAsync(cancellationToken);
            //获取这个组织的负责人
            var superiorUserId = userOrg.GetProperty<Guid?>(nameof(JhOrganizationUnit.LeaderId));
            if (superiorUserId.Equals(userId))//创建实例人与负责人不相等时处理，否则返回null跳过该步骤
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
            var data = await IdentityUsers.FirstOrDefaultAsync(a => a.Id == superiorUserId, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return default;
        }
	}
}
