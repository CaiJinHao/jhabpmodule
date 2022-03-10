using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.JhMenu.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapRepository : CrudRepository<JhMenuDbContext, MenuRoleMap, System.Guid>, IMenuRoleMapRepository
	{
		 protected readonly IMenuRoleMapDapperRepository MenuRoleMapDapperRepository;
		 public MenuRoleMapRepository(IDbContextProvider<JhMenuDbContext> dbContextProvider, IMenuRoleMapDapperRepository menurolemapDapperRepository) : base(dbContextProvider)
		{
			MenuRoleMapDapperRepository=menurolemapDapperRepository;
		}
	}
}
