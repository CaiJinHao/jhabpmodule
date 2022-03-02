using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(WorkflowDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class WorkflowApplicationContractsModule : AbpModule
{

}
