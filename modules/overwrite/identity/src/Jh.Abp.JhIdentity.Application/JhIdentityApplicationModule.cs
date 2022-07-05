using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Identity;
using Volo.Abp.SettingManagement;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpSettingManagementApplicationModule),
    typeof(JhIdentityDomainModule),
    typeof(JhIdentityApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
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
