using Jh.Abp.JhIdentity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhMenuDomainModule),
    typeof(JhMenuApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(JhIdentityApplicationContractsModule),
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
