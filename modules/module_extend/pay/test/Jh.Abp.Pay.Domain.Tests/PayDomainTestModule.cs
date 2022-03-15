using Jh.Abp.Pay.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.Pay;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(PayEntityFrameworkCoreTestModule)
    )]
public class PayDomainTestModule : AbpModule
{

}
