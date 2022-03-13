using Jh.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

[ConnectionStringName(WorkflowDbProperties.ConnectionStringName)]
public class WorkflowDbContext : JhAbpDbContext<WorkflowDbContext>, IWorkflowDbContext
{
    public DbSet<WorkflowInstance> WorkflowInstances { get; set; }
    public DbSet<WorkflowExtensionAttribute> WorkflowExtensionAttributes { get; set; }
    public DbSet<WorkflowExecutionPointer> WorkflowExecutionPointers { get; set; }
    public DbSet<WorkflowExecutionError> WorkflowExecutionErrors { get; set; }
    public DbSet<WorkflowEventSubscription> WorkflowEventSubscriptions { get; set; }
    public DbSet<WorkflowEvent> WorkflowEvents { get; set; }
    public DbSet<WorkflowScheduledCommand> WorkflowScheduledCommands { get; set; }
    public DbSet<WorkflowDefinition> WorkflowDefinitions { get; set; }


    public WorkflowDbContext(DbContextOptions<WorkflowDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureWorkflow();
    }
}
