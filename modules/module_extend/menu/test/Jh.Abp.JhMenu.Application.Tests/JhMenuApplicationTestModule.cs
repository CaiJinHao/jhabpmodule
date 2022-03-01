using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhMenuApplicationModule),
    typeof(JhMenuDomainTestModule)
    )]
public class JhMenuApplicationTestModule : AbpModule
{

}
