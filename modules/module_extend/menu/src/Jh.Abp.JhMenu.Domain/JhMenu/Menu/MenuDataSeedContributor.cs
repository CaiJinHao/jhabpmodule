using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.JhMenu.JhMenu.Menu
{
    public class MenuDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        protected IMenuDataSeeder MenuDataSeeder { get; }

        public MenuDataSeedContributor(IMenuDataSeeder menuDataSeeder)
        {
            MenuDataSeeder = menuDataSeeder;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            var roleid = context?["RoleId"] as Guid?;
            if (roleid != null)
            {
                var menuRegisterType = MenuRegisterType.SystemSetting;
                var _t = context?["MenuRegisterType"];
                if (_t != null)
                {
                    menuRegisterType = (MenuRegisterType)Convert.ToInt32(_t);
                }
                await MenuDataSeeder.SeedAsync((Guid)roleid, menuRegisterType,context.TenantId);
            }
        }
    }
}
