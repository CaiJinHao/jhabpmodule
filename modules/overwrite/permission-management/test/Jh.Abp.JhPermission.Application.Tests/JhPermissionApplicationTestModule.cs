using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(JhPermissionApplicationModule),
    typeof(JhPermissionDomainTestModule)
    )]
public class JhPermissionApplicationTestModule : AbpModule
{

}
