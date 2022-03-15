using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.JhMenu.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
			return (await GetDbSetAsync()).AsNoTracking()
				.Where(mn => mn.MenuCode.StartsWith(code) && mn.MenuCode != code);
        }

		public async Task<string> GetMaxMenuCodeAsync(string parentCode)
		{
			return (await GetDbSetAsync()).AsNoTracking().Where(a => a.MenuParentCode == parentCode).Max(a=>a.MenuCode);
		}
	}
}
