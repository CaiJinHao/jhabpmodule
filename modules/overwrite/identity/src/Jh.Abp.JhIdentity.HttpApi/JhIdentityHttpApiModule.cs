using Localization.Resources.AbpUi;
using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(JhIdentityApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class JhIdentityHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(JhIdentityHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<JhIdentityResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
