using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

[DependsOn(
    typeof(YourProjectNameDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class YourProjectNameEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<YourProjectNameDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
