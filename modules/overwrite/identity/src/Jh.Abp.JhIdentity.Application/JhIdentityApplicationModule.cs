using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(JhIdentityDomainModule),
    typeof(JhIdentityApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class JhIdentityApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhIdentityApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<JhIdentityApplicationModule>(validate: true);
        });
    }
}
