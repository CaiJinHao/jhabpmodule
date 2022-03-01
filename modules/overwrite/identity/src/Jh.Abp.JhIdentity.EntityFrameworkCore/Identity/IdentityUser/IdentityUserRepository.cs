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
            //��ȡ�û�������֯
            var userOrg = await (from user in dbContext.Set<IdentityUser>()
                                    join userOu in dbContext.Set<IdentityUserOrganizationUnit>() on user.Id equals userOu.UserId
									join ou in dbContext.OrganizationUnits on userOu.OrganizationUnitId equals ou.Id
                                    where user.Id == userId
                                    select ou).FirstOrDefaultAsync();
            //��ȡ�����֯�ĸ�����
            var superiorUserId = userOrg.GetProperty<Guid>(nameof(ObjectExtensionConst.OrganizationUnit.LeaderId));
            if (superiorUserId.Equals(userId))//����ʵ�����븺���˲����ʱ�������򷵻�null�����ò���
            {
                //��ǰ�û�����֯������ʱ����ȡ�ϼ���֯������
                var parentOrg = await dbContext.OrganizationUnits.FirstOrDefaultAsync(a => a.Id == userOrg.ParentId);
                superiorUserId = parentOrg.GetProperty<Guid>(nameof(ObjectExtensionConst.OrganizationUnit.LeaderId));
                if (superiorUserId.Equals(Guid.Empty))
                {
                    return default;//�Ҳ����ϼ��������ò��裬todo:û���ϼ��쵼��ʱ��ù�����������
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
