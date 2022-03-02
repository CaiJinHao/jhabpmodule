using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

[ConnectionStringName(WorkflowDbProperties.ConnectionStringName)]
public class WorkflowDbContext : AbpDbContext<WorkflowDbContext>, IWorkflowDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

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
