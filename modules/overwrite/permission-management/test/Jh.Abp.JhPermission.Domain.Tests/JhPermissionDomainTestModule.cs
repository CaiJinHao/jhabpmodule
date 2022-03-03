using Jh.Abp.JhPermission.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(JhPermissionEntityFrameworkCoreTestModule)
    )]
public class JhPermissionDomainTestModule : AbpModule
{

}
