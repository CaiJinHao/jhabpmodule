using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

public class YourProjectNameHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<YourProjectNameHttpApiHostMigrationsDbContext>
{
    public YourProjectNameHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString("YourProjectName");

        var builder = new DbContextOptionsBuilder<YourProjectNameHttpApiHostMigrationsDbContext>()
        //.UseSqlServer(configuration.GetConnectionString("YourProjectName"));
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


        return new YourProjectNameHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
