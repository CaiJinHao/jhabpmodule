using Jh.Abp.Workflow.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(WorkflowApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class WorkflowHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(WorkflowHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<WorkflowResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
