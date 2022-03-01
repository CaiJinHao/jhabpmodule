using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.JhIdentity.Blazor.Menus;

public class JhIdentityMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(JhIdentityMenus.Prefix, displayName: "JhIdentity", "/JhIdentity", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
