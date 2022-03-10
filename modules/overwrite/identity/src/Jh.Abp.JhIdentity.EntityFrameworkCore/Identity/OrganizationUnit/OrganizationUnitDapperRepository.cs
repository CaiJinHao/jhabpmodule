using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitDapperRepository : DapperRepository<JhIdentityDbContext>, IOrganizationUnitDapperRepository, ITransientDependency
	{
		public OrganizationUnitDapperRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
