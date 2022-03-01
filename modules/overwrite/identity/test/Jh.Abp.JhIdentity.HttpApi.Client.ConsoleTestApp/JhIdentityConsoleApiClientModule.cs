using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(JhIdentityHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class JhIdentityConsoleApiClientModule : AbpModule
{

}
