using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhIdentity
{
    public class IdentityUserDapperRepository : DapperRepository<JhIdentityDbContext>, IIdentityUserDapperRepository, ITransientDependency
	{
		public IdentityUserDapperRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
