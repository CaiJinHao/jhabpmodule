using Jh.Abp.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity.MongoDB;

[DependsOn(
    typeof(JhIdentityDomainModule),
    typeof(JhAbpMongoDBModule),
    typeof(AbpMongoDbModule)
    )]
public class JhIdentityMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<JhIdentityMongoDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, MongoQuestionRepository>();
             */
            //为非聚合根的实体也创建默认仓储
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
