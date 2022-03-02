using YourCompany.YourProjectName.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(YourProjectNameEntityFrameworkCoreTestModule)
    )]
public class YourProjectNameDomainTestModule : AbpModule
{

}
