using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Jh.Abp.JhMenu
{
    public class MenuDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        public IMenuDataSeeder MenuDataSeeder { get; set; }
        private readonly ICurrentTenant _currentTenant;
        public MenuDataSeedContributor(
            ICurrentTenant currentTenant
            )
        {
            _currentTenant = currentTenant;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                await MenuDataSeeder.SeedAsync();
            }
        }
    }
}
