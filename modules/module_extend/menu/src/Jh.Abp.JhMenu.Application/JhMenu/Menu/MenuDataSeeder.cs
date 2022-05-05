using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Jh.Abp.JhIdentity;
using Microsoft.EntityFrameworkCore;

namespace Jh.Abp.JhMenu
{
    internal class MenuDataSeeder : ITransientDependency, IMenuDataSeeder
    {
        public IJhIdentityRoleAppService jhIdentityRoleAppService { get; set; }
        private readonly MenuRoleMapManager MenuRoleMapManager;
        private readonly IMenuRepository MenuRepository;
        public MenuDataSeeder(IMenuRepository menuRepository,
            MenuRoleMapManager menuRoleMapManager
            )
        {
            MenuRepository = menuRepository;
            MenuRoleMapManager = menuRoleMapManager;
        }

        public virtual async Task SeedAsync()
        {
            var adminRoleId = await jhIdentityRoleAppService.GetAdminRoleIdAsync();
            if (adminRoleId.HasValue)
            {
                var menuIds = await (await MenuRepository.GetQueryableAsync()).AsNoTracking().Select(a => a.Id).ToListAsync();
                await MenuRoleMapManager.InitMenuByRoleAsync(adminRoleId.Value, menuIds.ToArray());
            }
        }

        public virtual async Task MenuCreateEventSeedAsync(Guid menuId)
        {
            var adminRoleId = await jhIdentityRoleAppService.GetAdminRoleIdAsync();
            if (adminRoleId.HasValue)
            {
                await MenuRoleMapManager.InitMenuByRoleAsync(adminRoleId.Value,new Guid[] { menuId });
            }
        }
    }
}
