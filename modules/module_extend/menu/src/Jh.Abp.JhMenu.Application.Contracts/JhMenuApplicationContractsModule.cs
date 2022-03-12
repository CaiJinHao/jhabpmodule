using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Jh.Abp.Application.Contracts;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhAbpContractsModule),
    typeof(JhMenuDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class JhMenuApplicationContractsModule : AbpModule
{

}
