using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Jh.Abp.JhMenu.JhMenu.Menu
{
    public class MenuDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly MenuRoleMapManager MenuRoleMapManager;
        protected IMenuRepository MenuRepository;
        public MenuDataSeedContributor(
            ICurrentTenant currentTenant,
            MenuRoleMapManager menuRoleMapManager,
            IMenuRepository menuRepository
            )
        {
            _currentTenant = currentTenant;
            MenuRoleMapManager = menuRoleMapManager;
            MenuRepository = menuRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var roleid = context.Properties["RoleId"].ToString();
            if (string.IsNullOrEmpty(roleid))
            {
                throw new Exception("请传入admin角色id");
            }
            using (_currentTenant.Change(context?.TenantId))
            {
                var menuIds = await (await MenuRepository.GetQueryableAsync()).AsNoTracking().Where(a => a.IsDeleted == false).Select(a => a.Id).ToListAsync();
                await MenuRoleMapManager.InitMenuByRoleAsync(new Guid(roleid), menuIds.ToArray());
            }
        }
    }
}
