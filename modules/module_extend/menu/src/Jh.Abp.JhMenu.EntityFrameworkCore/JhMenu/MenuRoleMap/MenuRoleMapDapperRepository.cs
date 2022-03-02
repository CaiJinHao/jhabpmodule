using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhMenu.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Dapper;
namespace Jh.Abp.JhMenu
{
	public class MenuRoleMapDapperRepository : DapperRepository<JhMenuDbContext>, IMenuRoleMapDapperRepository, ITransientDependency
	{
		public MenuRoleMapDapperRepository(IDbContextProvider<JhMenuDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
