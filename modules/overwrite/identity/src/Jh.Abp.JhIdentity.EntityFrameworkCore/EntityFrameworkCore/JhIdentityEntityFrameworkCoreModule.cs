using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

[DependsOn(
    typeof(JhIdentityDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class JhIdentityEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        JhIdentityDbContextModelCreatingExtensions.ConfigureExtensionDomain();
    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<JhIdentityDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
