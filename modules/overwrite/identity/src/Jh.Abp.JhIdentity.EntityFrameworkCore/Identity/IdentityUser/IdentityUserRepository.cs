using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public class IdentityUserRepository : CrudRepository<IIdentityDbContext, Volo.Abp.Identity.IdentityUser, System.Guid>, IIdentityUserRepository
	{
		 public IdentityUserRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}

		public virtual async Task<List<Volo.Abp.Identity.IdentityRole>> GetRolesAsync(
			Guid userid,
			bool includeDetails = false,
			CancellationToken cancellationToken = default)
		{
			var dbContext = await GetDbContextAsync();

			var query = from userRole in dbContext.Set<IdentityUserRole>()
						join role in dbContext.Roles.IncludeDetails(includeDetails) on userRole.RoleId equals role.Id
						where userRole.UserId == userid
						select role;

			return await query.ToListAsync(GetCancellationToken(cancellationToken));
		}

		public virtual async Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(
			Guid id,
			CancellationToken cancellationToken = default)
		{
			var dbContext = await GetDbContextAsync();

			//获取用户所属组织
			var query = from user in dbContext.Set<IdentityUser>()
								 join userOu in dbContext.Set<IdentityUserOrganizationUnit>() on user.Id equals userOu.UserId
								 join ou in dbContext.OrganizationUnits on userOu.OrganizationUnitId equals ou.Id
								 where user.Id == id
							   select ou;

            return await query.ToListAsync(GetCancellationToken(cancellationToken));
		}

		/*public virtual async Task<IdentityUser> GetSuperiorUserAsync(Guid userId,CancellationToken cancellationToken = default)
		{
			var dbContext = await GetDbContextAsync();
            //获取用户所属组织
            var userOrg = await (from user in dbContext.Set<IdentityUser>()
                                    join userOu in dbContext.Set<IdentityUserOrganizationUnit>() on user.Id equals userOu.UserId
									join ou in dbContext.OrganizationUnits on userOu.OrganizationUnitId equals ou.Id
                                    where user.Id == userId orderby userOu.CreationTime descending
                                    select ou).FirstOrDefaultAsync(cancellationToken);
            //获取这个组织的负责人
            var superiorUserId = userOrg.GetProperty<Guid?>(nameof(JhOrganizationUnit.LeaderId));
            if (superiorUserId.Equals(userId))//创建实例人与负责人不相等时处理，否则返回null跳过该步骤
            {
                //当前用户是组织负责人时，获取上级组织负责人
                if (userOrg.ParentId.HasValue)
                {
					var parentOrg = await jhIdentityDbContext.OrganizationUnits.FirstOrDefaultAsync(a => a.Id == userOrg.ParentId, cancellationToken);
					superiorUserId = parentOrg.LeaderId;
					if (superiorUserId.Equals(Guid.Empty))
					{
						return default;//找不到上级，跳过该步骤，todo:没有上级领导的时候该工作流不成立
					}
				}
            }
            var data = await dbContext.Users.FirstOrDefaultAsync(a => a.Id == superiorUserId, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return default;
        }*/

		public virtual async Task<IQueryable<IdentityUser>> GetByOrganizationUnitCodeAsync(IQueryable<IdentityUser> entity,string organizationUnitCode)
		{
            var dbContext = await GetDbContextAsync();
            var queryOrganizationUnit = dbContext.OrganizationUnits.Where(a => a.Code.StartsWith(organizationUnitCode));

            var userOrgs = dbContext.Set<IdentityUserOrganizationUnit>();
            return from user in entity
                   join userOrg in userOrgs on user.Id equals userOrg.UserId
                   join org in queryOrganizationUnit on userOrg.OrganizationUnitId equals org.Id
                   select user;
        }
	}
}
