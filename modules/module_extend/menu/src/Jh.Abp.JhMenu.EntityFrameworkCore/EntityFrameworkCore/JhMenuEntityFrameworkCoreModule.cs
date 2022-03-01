using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

[DependsOn(
    typeof(JhMenuDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class JhMenuEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<JhMenuDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
