using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YourProjectNameHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class YourProjectNameConsoleApiClientModule : AbpModule
{

}
