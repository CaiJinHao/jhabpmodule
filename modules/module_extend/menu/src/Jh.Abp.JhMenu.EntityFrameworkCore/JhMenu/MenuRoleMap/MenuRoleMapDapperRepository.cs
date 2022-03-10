using Jh.Abp.JhMenu.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapDapperRepository : DapperRepository<JhMenuDbContext>, IMenuRoleMapDapperRepository, ITransientDependency
	{
		public MenuRoleMapDapperRepository(IDbContextProvider<JhMenuDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
