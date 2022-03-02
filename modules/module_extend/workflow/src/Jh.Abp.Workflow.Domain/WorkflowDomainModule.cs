using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(WorkflowDomainSharedModule)
)]
public class WorkflowDomainModule : AbpModule
{

}
