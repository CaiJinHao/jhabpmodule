using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(JhIdentityDomainSharedModule)
)]
public class JhIdentityDomainModule : AbpModule
{

}
