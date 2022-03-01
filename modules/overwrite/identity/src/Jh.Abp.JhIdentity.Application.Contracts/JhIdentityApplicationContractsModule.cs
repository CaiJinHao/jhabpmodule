using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(JhIdentityDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class JhIdentityApplicationContractsModule : AbpModule
{

}
