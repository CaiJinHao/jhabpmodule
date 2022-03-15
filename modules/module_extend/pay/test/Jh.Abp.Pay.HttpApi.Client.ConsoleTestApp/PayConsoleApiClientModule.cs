using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Jh.Abp.Pay;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PayHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class PayConsoleApiClientModule : AbpModule
{

}
