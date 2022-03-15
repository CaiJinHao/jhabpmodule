using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jh.Abp.Pay.EntityFrameworkCore;

public class PayHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<PayHttpApiHostMigrationsDbContext>
{
    public PayHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PayHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Pay"));

        return new PayHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
