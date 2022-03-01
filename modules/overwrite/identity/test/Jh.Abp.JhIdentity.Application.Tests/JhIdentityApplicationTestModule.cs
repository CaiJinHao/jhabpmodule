using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(JhIdentityApplicationModule),
    typeof(JhIdentityDomainTestModule)
    )]
public class JhIdentityApplicationTestModule : AbpModule
{

}
