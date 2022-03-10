using Jh.Abp.JhMenu.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhMenu
{
    public class MenuDapperRepository : DapperRepository<JhMenuDbContext>, IMenuDapperRepository, ITransientDependency
	{
		public MenuDapperRepository(IDbContextProvider<JhMenuDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
