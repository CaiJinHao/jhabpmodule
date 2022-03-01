using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(JhIdentityEntityFrameworkCoreTestModule)
    )]
public class JhIdentityDomainTestModule : AbpModule
{

}
