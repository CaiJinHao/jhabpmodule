using Microsoft.Extensions.DependencyInjection;
using Jh.Abp.JhIdentity.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Jh.Abp.JhIdentity.Blazor;

[DependsOn(
    typeof(JhIdentityApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class JhIdentityBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhIdentityBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<JhIdentityBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new JhIdentityMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(JhIdentityBlazorModule).Assembly);
        });
    }
}
