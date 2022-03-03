using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission.EntityFrameworkCore;

[DependsOn(
    typeof(JhPermissionDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class JhPermissionEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<JhPermissionDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
