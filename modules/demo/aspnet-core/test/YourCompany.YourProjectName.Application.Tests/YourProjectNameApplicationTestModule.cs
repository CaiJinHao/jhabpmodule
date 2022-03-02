using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(YourProjectNameApplicationModule),
    typeof(YourProjectNameDomainTestModule)
    )]
public class YourProjectNameApplicationTestModule : AbpModule
{

}
