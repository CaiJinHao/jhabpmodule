using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(JhPermissionDomainModule),
    typeof(JhPermissionApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class JhPermissionApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhPermissionApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<JhPermissionApplicationModule>(validate: true);
        });
    }
}
