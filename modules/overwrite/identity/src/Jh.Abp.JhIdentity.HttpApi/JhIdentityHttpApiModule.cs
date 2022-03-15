using Jh.Abp.JhIdentity.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

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
