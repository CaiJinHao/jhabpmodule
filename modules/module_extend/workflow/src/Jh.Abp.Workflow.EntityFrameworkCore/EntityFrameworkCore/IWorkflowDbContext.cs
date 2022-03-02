using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

[ConnectionStringName(WorkflowDbProperties.ConnectionStringName)]
public interface IWorkflowDbContext : IEfCoreDbContext
{
    DbSet<WorkflowDefinition> WorkflowDefinitions { get; }

    DbSet<WorkflowInstance> WorkflowInstances { get; }
    DbSet<WorkflowExtensionAttribute> WorkflowExtensionAttributes { get; }
    DbSet<WorkflowExecutionPointer> WorkflowExecutionPointers { get; }
    DbSet<WorkflowExecutionError> WorkflowExecutionErrors { get; }
    DbSet<WorkflowEventSubscription> WorkflowEventSubscriptions { get; }
    DbSet<WorkflowEvent> WorkflowEvents { get; }
    DbSet<WorkflowScheduledCommand> WorkflowScheduledCommands { get; }
}
