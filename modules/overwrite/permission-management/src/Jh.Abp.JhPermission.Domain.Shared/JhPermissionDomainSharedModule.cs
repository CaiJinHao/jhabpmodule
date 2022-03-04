using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Jh.Abp.JhPermission.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Jh.Abp.Domain.Localization;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class JhPermissionDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JhPermissionDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<JhPermissionResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(JhAbpExtensionsResource))
                .AddVirtualJson("/Localization/JhPermission");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("JhPermission", typeof(JhPermissionResource));
        });
    }
}
