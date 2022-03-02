using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(YourProjectNameDomainModule),
    typeof(YourProjectNameApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class YourProjectNameApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<YourProjectNameApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<YourProjectNameApplicationModule>(validate: true);
        });
    }
}
