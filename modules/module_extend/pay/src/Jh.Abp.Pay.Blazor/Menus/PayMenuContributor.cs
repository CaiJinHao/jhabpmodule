using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.Pay.Blazor.Menus;

public class PayMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(PayMenus.Prefix, displayName: "Pay", "/Pay", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
