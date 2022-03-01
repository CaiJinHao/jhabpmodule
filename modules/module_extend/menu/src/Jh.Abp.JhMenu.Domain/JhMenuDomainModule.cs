using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(JhMenuDomainSharedModule)
)]
public class JhMenuDomainModule : AbpModule
{

}
