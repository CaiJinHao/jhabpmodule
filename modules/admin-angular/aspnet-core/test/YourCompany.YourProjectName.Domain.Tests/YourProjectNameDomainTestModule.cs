using YourCompany.YourProjectName.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(YourProjectNameEntityFrameworkCoreTestModule)
    )]
public class YourProjectNameDomainTestModule : AbpModule
{

}
