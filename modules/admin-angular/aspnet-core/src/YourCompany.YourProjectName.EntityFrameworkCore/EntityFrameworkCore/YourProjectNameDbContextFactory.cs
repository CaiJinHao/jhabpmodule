using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class YourProjectNameDbContextFactory : IDesignTimeDbContextFactory<YourProjectNameDbContext>
{
    public YourProjectNameDbContext CreateDbContext(string[] args)
    {
        YourProjectNameEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<YourProjectNameDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new YourProjectNameDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../YourCompany.YourProjectName.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
