using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

public class JhMenuHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<JhMenuHttpApiHostMigrationsDbContext>
{
    public JhMenuHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString(JhMenuDbProperties.ConnectionStringName);

        var builder = new DbContextOptionsBuilder<JhMenuHttpApiHostMigrationsDbContext>()
            .UseSqlServer(connectionString);
        //.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new JhMenuHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
