using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Jh.Abp.Domain.Localization;
using Jh.Abp.Domain.Shared;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(JhAbpExtensionsDomainSharedModule)
)]
public class JhIdentityDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JhIdentityDomainSharedModule>(typeof(JhIdentityDomainSharedModule).Namespace);
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<JhIdentityResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(JhAbpExtensionsResource))
                .AddVirtualJson("/Localization/JhIdentity");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("JhIdentity", typeof(JhIdentityResource));
        });
    }
}
