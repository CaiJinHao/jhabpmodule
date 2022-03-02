using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;
using WorkflowCore.Interface;
using WorkflowCore.Services;

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

            options.Entity<WorkflowInstance>(opt =>
            {
                opt.DefaultWithDetailsFunc = q => q.Include(a => a.ExecutionPointers);
            });
            options.Entity<WorkflowExecutionPointer>(opt =>
            {
                opt.DefaultWithDetailsFunc = q => q.Include(a => a.ExtensionAttributes);
            });
        });

        context.Services.AddWorkflow(options => {
            options.UsePersistence(sp => context.Services.GetRequiredService<IPersistenceProvider>());
            options.UseEventHub((sp => new SingleNodeEventHub(sp.GetService<ILoggerFactory>())));
        });
        context.Services.AddWorkflowDSL();
        context.Services.Replace(ServiceDescriptor.Singleton<IPersistenceProvider, EntityFrameworkPersistenceProvider>());
        context.Services.Replace(ServiceDescriptor.Transient<ILifeCycleEventPublisher, LifeCycleEventPublisher>());//改为瞬时
        //context.Services.Replace(ServiceDescriptor.Singleton<ILifeCycleEventPublisher, JhLifeCycleEventPublisher>());//改为自定义
    }
}
