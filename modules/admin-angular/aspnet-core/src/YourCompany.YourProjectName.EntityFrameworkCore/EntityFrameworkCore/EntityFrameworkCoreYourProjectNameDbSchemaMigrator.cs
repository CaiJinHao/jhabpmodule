using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YourCompany.YourProjectName.Data;
using Volo.Abp.DependencyInjection;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

public class EntityFrameworkCoreYourProjectNameDbSchemaMigrator
    : IYourProjectNameDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreYourProjectNameDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the YourProjectNameDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<YourProjectNameDbContext>()
            .Database
            .MigrateAsync();
    }
}
