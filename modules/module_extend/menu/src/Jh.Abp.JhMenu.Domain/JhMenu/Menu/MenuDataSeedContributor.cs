using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace Jh.Abp.JhMenu
{
    public class MenuDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        public ILogger<MenuDataSeedContributor> Logger { get; set; }
        protected MenuManager menuManager { get; }
        public MenuDataSeedContributor(MenuManager MenuManager)
        {
            menuManager = MenuManager;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            return Task.CompletedTask;
        }
    }
}
