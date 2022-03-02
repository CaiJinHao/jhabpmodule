using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

[DependsOn(
    typeof(WorkflowDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class WorkflowEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<WorkflowDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
