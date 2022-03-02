using Localization.Resources.AbpUi;
using Jh.Abp.Workflow.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Jh.Abp.Workflow.EntityFrameworkCore;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(WorkflowApplicationModule),
    typeof(WorkflowApplicationContractsModule),
    typeof(WorkflowEntityFrameworkCoreModule),
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
