using Jh.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleRepository : CrudRepository<IIdentityDbContext, Volo.Abp.Identity.IdentityRole, System.Guid>, IJhIdentityRoleRepository
	{
		 protected readonly IIdentityRoleDapperRepository IdentityRoleDapperRepository;
		 public JhIdentityRoleRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider, IIdentityRoleDapperRepository identityroleDapperRepository) : base(dbContextProvider)
		{
			IdentityRoleDapperRepository=identityroleDapperRepository;
		}
	}
}
