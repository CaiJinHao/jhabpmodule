using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleRepository : CrudRepository<JhIdentityDbContext, Volo.Abp.Identity.IdentityRole, System.Guid>, IJhIdentityRoleRepository
	{
		 protected readonly IIdentityRoleDapperRepository IdentityRoleDapperRepository;
		 public JhIdentityRoleRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider, IIdentityRoleDapperRepository identityroleDapperRepository) : base(dbContextProvider)
		{
			IdentityRoleDapperRepository=identityroleDapperRepository;
		}
	}
}
