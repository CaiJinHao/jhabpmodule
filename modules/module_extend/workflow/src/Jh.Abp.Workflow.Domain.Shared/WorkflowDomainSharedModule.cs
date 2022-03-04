using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Jh.Abp.Workflow.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Jh.Abp.Domain.Localization;
using Jh.Abp.Domain.Shared;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(JhAbpExtensionsDomainSharedModule)
)]
public class WorkflowDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WorkflowDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<WorkflowResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(JhAbpExtensionsResource))
                .AddVirtualJson("/Localization/Workflow");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Workflow", typeof(WorkflowResource));
        });
    }
}
