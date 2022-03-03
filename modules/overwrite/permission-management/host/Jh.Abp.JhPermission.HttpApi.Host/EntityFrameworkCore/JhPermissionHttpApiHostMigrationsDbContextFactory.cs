using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jh.Abp.JhPermission.EntityFrameworkCore;

public class JhPermissionHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<JhPermissionHttpApiHostMigrationsDbContext>
{
    public JhPermissionHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<JhPermissionHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("JhPermission"));

        return new JhPermissionHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
