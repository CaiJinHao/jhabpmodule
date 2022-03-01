using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhMenuDomainModule),
    typeof(JhMenuApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class JhMenuApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhMenuApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<JhMenuApplicationModule>(validate: true);
        });
    }
}
