using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Jh.Abp.Domain.Localization;
using Jh.Abp.Domain.Shared;
using Volo.Abp.Identity.Localization;

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
            //重写资源类型得本地化文件
            options.Resources
                .Get<AbpValidationResource>()
                .AddVirtualJson("/Localization/JhIdentity");

            options.Resources
               .Get<IdentityResource>()
               .AddVirtualJson("/Localization/JhIdentity");


            //新的资源文件类型,继承，用得时候必须用该资源类型
            options.Resources
                .Add<JhIdentityResource>("zh-Hans")
                .AddBaseTypes(typeof(IdentityResource))
                .AddBaseTypes(typeof(JhAbpExtensionsResource))
                .AddVirtualJson("/Localization/JhIdentity");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("JhIdentity", typeof(JhIdentityResource));
        });
    }
}
