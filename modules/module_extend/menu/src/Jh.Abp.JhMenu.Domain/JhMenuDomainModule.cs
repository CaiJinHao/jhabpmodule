using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(JhMenuDomainSharedModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpAutoMapperModule)
)]
public class JhMenuDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JhMenuDomainModule>();


        Configure<AbpDistributedEntityEventOptions>(options =>
        {
            
        });
    }
}
