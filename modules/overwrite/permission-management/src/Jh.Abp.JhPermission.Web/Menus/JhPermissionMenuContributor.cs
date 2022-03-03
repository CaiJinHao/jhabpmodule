using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.JhPermission.Web.Menus;

public class JhPermissionMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(JhPermissionMenus.Prefix, displayName: "JhPermission", "~/JhPermission", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
