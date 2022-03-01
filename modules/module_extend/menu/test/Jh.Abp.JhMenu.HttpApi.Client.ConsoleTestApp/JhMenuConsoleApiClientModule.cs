using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(JhMenuHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class JhMenuConsoleApiClientModule : AbpModule
{

}
