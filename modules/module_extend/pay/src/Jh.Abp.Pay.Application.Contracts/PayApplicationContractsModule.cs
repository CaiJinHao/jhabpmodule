using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Jh.Abp.Pay;

[DependsOn(
    typeof(PayDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PayApplicationContractsModule : AbpModule
{

}
