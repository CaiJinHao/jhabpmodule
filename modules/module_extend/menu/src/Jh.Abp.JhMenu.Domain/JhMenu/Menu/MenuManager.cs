
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
namespace Jh.Abp.JhMenu
{
    public class MenuManager : DomainService
    {
        protected IMenuRepository MenuRepository => LazyServiceProvider.LazyGetRequiredService<IMenuRepository>();

        public async Task<Menu> CreateAsync(Menu menu)
        {
            menu.MenuDescription = menu.MenuName;
            menu.TenantId = CurrentTenant?.Id;
            return await MenuRepository.CreateAsync(menu,true);
        }
    }
}
