using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace YourCompany.YourProjectName.MongoDB;

[DependsOn(
    typeof(YourProjectNameDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class YourProjectNameMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<YourProjectNameMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
