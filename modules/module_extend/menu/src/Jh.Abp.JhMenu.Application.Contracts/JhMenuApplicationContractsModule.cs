using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhMenuDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class JhMenuApplicationContractsModule : AbpModule
{

}
