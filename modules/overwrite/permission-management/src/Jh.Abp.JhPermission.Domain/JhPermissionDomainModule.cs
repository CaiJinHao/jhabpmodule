using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(JhPermissionDomainSharedModule)
)]
public class JhPermissionDomainModule : AbpModule
{

}
