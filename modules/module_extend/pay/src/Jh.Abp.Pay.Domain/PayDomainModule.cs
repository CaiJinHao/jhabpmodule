using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jh.Abp.Pay;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PayDomainSharedModule)
)]
public class PayDomainModule : AbpModule
{

}
