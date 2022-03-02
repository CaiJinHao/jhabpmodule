using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(WorkflowApplicationModule),
    typeof(WorkflowDomainTestModule)
    )]
public class WorkflowApplicationTestModule : AbpModule
{

}
