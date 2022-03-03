using Microsoft.Extensions.DependencyInjection;
using Jh.Abp.JhPermission.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.JhPermission.Blazor;

[DependsOn(
    typeof(JhPermissionApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class JhPermissionBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhPermissionBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<JhPermissionBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new JhPermissionMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(JhPermissionBlazorModule).Assembly);
        });
    }
}
