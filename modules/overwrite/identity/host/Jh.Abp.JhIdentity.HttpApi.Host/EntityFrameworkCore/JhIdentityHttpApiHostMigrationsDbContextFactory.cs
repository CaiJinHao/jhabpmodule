using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

public class JhIdentityHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<JhIdentityHttpApiHostMigrationsDbContext>
{
    public JhIdentityHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<JhIdentityHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("JhIdentity"));

        return new JhIdentityHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
