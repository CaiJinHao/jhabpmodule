using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public class IdentityUserRepository : CrudRepository<JhIdentityDbContext, Volo.Abp.Identity.IdentityUser, System.Guid>, IIdentityUserRepository
	{
		 protected readonly IIdentityUserDapperRepository IdentityUserDapperRepository;
		 public IdentityUserRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider, IIdentityUserDapperRepository identityuserDapperRepository) : base(dbContextProvider)
		{
			IdentityUserDapperRepository=identityuserDapperRepository;
		}

		public virtual async Task<List<Volo.Abp.Identity.IdentityRole>> GetRolesAsync(
			Guid id,
			bool includeDetails = false,
			CancellationToken cancellationToken = default)
		{
			var dbContext = await GetDbContextAsync();

			var query = from userRole in dbContext.Set<IdentityUserRole>()
						join role in dbContext.Roles.IncludeDetails(includeDetails) on userRole.RoleId equals role.Id
						where userRole.UserId == id
						select role;

			return await query.ToListAsync(GetCancellationToken(cancellationToken));
		}

		public virtual async Task<IdentityUser> GetSuperiorUserAsync(Guid userId,CancellationToken cancellationToken = default)
		{
			var dbContext = await GetDbContextAsync();
            //获取用户所属组织
            var userOrg = await (from user in dbContext.Set<IdentityUser>()
                                    join userOu in dbContext.Set<IdentityUserOrganizationUnit>() on user.Id equals userOu.UserId
									join ou in dbContext.OrganizationUnits on userOu.OrganizationUnitId equals ou.Id
                                    where user.Id == userId
                                    select ou).FirstOrDefaultAsync();
            //获取这个组织的负责人
            var superiorUserId = userOrg.GetProperty<Guid>(nameof(ObjectExtensionConst.OrganizationUnit.LeaderId));
            if (superiorUserId.Equals(userId))//创建实例人与负责人不相等时处理，否则返回null跳过该步骤
            {
                //当前用户是组织负责人时，获取上级组织负责人
                var parentOrg = await dbContext.OrganizationUnits.FirstOrDefaultAsync(a => a.Id == userOrg.ParentId);
                superiorUserId = parentOrg.GetProperty<Guid>(nameof(ObjectExtensionConst.OrganizationUnit.LeaderId));
                if (superiorUserId.Equals(Guid.Empty))
                {
                    return default;//找不到上级，跳过该步骤，todo:没有上级领导的时候该工作流不成立
                }
            }
            var data = await dbContext.Users.FirstOrDefaultAsync(a => a.Id == superiorUserId);
            if (data != null)
            {
                return data;
            }
            return default;
        }
	}
}
