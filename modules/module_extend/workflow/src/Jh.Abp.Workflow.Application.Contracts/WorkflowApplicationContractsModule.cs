using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Jh.Abp.JhIdentity;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(WorkflowDomainSharedModule),
    typeof(JhIdentityApplicationContractsModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class WorkflowApplicationContractsModule : AbpModule
{

}
