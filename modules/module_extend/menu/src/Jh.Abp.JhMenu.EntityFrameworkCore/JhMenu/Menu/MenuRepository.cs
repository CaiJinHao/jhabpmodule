using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhMenu.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;


namespace Jh.Abp.JhMenu
{
	public class MenuRepository : CrudRepository<JhMenuDbContext, Menu, System.Guid>, IMenuRepository
	{
		 protected readonly IMenuDapperRepository MenuDapperRepository;
		 public MenuRepository(IDbContextProvider<JhMenuDbContext> dbContextProvider, IMenuDapperRepository menuDapperRepository) : base(dbContextProvider)
		{
			MenuDapperRepository=menuDapperRepository;
		}

		public virtual async Task<IQueryable<Menu>> GetAllChildren(
			string code,
			bool includeDetails = false,
		CancellationToken cancellationToken = default)
		{
			return (await GetDbSetAsync())
				.Where(mn => mn.MenuCode.StartsWith(code) && mn.MenuCode != code);

        }
	}
}
