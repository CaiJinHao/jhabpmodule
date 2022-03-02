using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using YourCompany.YourProjectName.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class YourProjectNameDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<YourProjectNameDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<YourProjectNameResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/YourProjectName");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("YourProjectName", typeof(YourProjectNameResource));
        });
    }
}
