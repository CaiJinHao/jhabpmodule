using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.JhMenu
{
    public interface IMenuDataSeeder
    {
        Task SeedAsync();
        Task MenuCreateEventSeedAsync(Guid menuId);
    }
}
