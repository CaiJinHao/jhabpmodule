using YourCompany.YourProjectName.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YourProjectNameEntityFrameworkCoreModule),
    typeof(YourProjectNameApplicationContractsModule)
    )]
public class YourProjectNameDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
