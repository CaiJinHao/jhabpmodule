using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.Workflow.Blazor.Menus;

public class WorkflowMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(WorkflowMenus.Prefix, displayName: "Workflow", "/Workflow", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
