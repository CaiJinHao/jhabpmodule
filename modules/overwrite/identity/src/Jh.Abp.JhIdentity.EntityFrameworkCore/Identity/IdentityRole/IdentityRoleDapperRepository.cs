using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Dapper;
namespace Jh.Abp.JhIdentity
{
	public class IdentityRoleDapperRepository : DapperRepository<JhIdentityDbContext>, IIdentityRoleDapperRepository, ITransientDependency
	{
		public IdentityRoleDapperRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
