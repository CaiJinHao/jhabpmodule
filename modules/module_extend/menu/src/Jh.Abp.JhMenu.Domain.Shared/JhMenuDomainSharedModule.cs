using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Jh.Abp.JhMenu.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Jh.Abp.Domain.Localization;
using Jh.Abp.Domain.Shared;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(JhAbpExtensionsDomainSharedModule)
)]
public class JhMenuDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JhMenuDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<JhMenuResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(JhAbpExtensionsResource))
                .AddVirtualJson("/Localization/JhMenu");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("JhMenu", typeof(JhMenuResource));
        });
    }
}
