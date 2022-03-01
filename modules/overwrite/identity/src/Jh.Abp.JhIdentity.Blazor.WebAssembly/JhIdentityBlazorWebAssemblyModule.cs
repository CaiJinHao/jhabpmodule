using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity.Blazor.WebAssembly;

[DependsOn(
    typeof(JhIdentityBlazorModule),
    typeof(JhIdentityHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class JhIdentityBlazorWebAssemblyModule : AbpModule
{

}
