using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhPermission.MongoDB;

[DependsOn(
    typeof(JhPermissionDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class JhPermissionMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<JhPermissionMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
