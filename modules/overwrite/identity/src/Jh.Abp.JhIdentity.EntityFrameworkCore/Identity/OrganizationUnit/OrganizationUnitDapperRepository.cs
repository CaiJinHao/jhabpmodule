using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Dapper;
namespace Jh.Abp.JhIdentity
{
	public class OrganizationUnitDapperRepository : DapperRepository<JhIdentityDbContext>, IOrganizationUnitDapperRepository, ITransientDependency
	{
		public OrganizationUnitDapperRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
