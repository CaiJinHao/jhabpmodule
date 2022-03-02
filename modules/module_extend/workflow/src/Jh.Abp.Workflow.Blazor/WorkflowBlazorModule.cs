using Microsoft.Extensions.DependencyInjection;
using Jh.Abp.Workflow.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.Workflow.Blazor;

[DependsOn(
    typeof(WorkflowApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class WorkflowBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<WorkflowBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<WorkflowBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new WorkflowMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(WorkflowBlazorModule).Assembly);
        });
    }
}
