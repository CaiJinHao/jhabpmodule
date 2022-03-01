using Microsoft.Extensions.DependencyInjection;
using Jh.Abp.JhMenu.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.JhMenu.Blazor;

[DependsOn(
    typeof(JhMenuApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class JhMenuBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhMenuBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<JhMenuBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new JhMenuMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(JhMenuBlazorModule).Assembly);
        });
    }
}
