using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

public class WorkflowHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<WorkflowHttpApiHostMigrationsDbContext>
{
    public WorkflowHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<WorkflowHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Workflow"));

        return new WorkflowHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
