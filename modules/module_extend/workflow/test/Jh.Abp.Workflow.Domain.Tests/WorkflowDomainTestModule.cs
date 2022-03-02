using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(WorkflowEntityFrameworkCoreTestModule)
    )]
public class WorkflowDomainTestModule : AbpModule
{

}
