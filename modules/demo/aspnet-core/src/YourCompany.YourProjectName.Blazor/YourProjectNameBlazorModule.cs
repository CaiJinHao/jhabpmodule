using Microsoft.Extensions.DependencyInjection;
using YourCompany.YourProjectName.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace YourCompany.YourProjectName.Blazor;

[DependsOn(
    typeof(YourProjectNameApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class YourProjectNameBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<YourProjectNameBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<YourProjectNameBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new YourProjectNameMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(YourProjectNameBlazorModule).Assembly);
        });
    }
}
