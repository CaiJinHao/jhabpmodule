using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace YourCompany.YourProjectName.Web.Menus;

public class YourProjectNameMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(YourProjectNameMenus.Prefix, displayName: "YourProjectName", "~/YourProjectName", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
