using Jh.Abp.JhMenu.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(JhMenuEntityFrameworkCoreTestModule)
    )]
public class JhMenuDomainTestModule : AbpModule
{

}
