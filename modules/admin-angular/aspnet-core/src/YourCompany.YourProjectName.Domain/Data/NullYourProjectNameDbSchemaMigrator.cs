using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace YourCompany.YourProjectName.Data;

/* This is used if database provider does't define
 * IYourProjectNameDbSchemaMigrator implementation.
 */
public class NullYourProjectNameDbSchemaMigrator : IYourProjectNameDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
