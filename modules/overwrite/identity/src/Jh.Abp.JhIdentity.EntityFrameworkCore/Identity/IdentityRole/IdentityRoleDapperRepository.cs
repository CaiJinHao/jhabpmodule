using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhIdentity
{
    public class IdentityRoleDapperRepository : DapperRepository<JhIdentityDbContext>, IIdentityRoleDapperRepository, ITransientDependency
	{
		public IdentityRoleDapperRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
