using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

public class WorkflowHttpApiHostMigrationsDbContext : AbpDbContext<WorkflowHttpApiHostMigrationsDbContext>
{
    public WorkflowHttpApiHostMigrationsDbContext(DbContextOptions<WorkflowHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureWorkflow();
    }
}
