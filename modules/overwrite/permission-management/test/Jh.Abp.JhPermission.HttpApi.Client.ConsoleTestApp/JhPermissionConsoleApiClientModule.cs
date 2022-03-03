using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(JhPermissionHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class JhPermissionConsoleApiClientModule : AbpModule
{

}
