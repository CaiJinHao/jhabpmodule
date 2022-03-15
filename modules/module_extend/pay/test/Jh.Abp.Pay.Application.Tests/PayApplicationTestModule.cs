using Volo.Abp.Modularity;

namespace Jh.Abp.Pay;

[DependsOn(
    typeof(PayApplicationModule),
    typeof(PayDomainTestModule)
    )]
public class PayApplicationTestModule : AbpModule
{

}
