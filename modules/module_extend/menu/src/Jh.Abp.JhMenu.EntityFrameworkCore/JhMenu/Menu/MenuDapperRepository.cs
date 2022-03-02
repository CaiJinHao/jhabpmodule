using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhMenu.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Dapper;
namespace Jh.Abp.JhMenu
{
	public class MenuDapperRepository : DapperRepository<JhMenuDbContext>, IMenuDapperRepository, ITransientDependency
	{
		public MenuDapperRepository(IDbContextProvider<JhMenuDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
