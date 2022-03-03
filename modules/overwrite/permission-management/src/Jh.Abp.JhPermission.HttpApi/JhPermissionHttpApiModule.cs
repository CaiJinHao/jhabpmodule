using Localization.Resources.AbpUi;
using Jh.Abp.JhPermission.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(JhPermissionApplicationContractsModule),
    typeof(JhPermissionApplicationModule),
    typeof(AbpAspNetCoreMvcModule))]
public class JhPermissionHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(JhPermissionHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<JhPermissionResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
