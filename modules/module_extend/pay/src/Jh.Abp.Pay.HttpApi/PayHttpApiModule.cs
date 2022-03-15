using Localization.Resources.AbpUi;
using Jh.Abp.Pay.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Jh.Abp.Pay;

[DependsOn(
    typeof(PayApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PayHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PayHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PayResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
