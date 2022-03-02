using Localization.Resources.AbpUi;
using YourCompany.YourProjectName.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(YourProjectNameApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class YourProjectNameHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(YourProjectNameHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<YourProjectNameResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
