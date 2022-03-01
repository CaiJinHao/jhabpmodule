using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.JhMenu.Blazor.Menus;

public class JhMenuMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(JhMenuMenus.Prefix, displayName: "JhMenu", "/JhMenu", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
