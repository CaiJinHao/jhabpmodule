using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(JhPermissionDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class JhPermissionApplicationContractsModule : AbpModule
{

}
