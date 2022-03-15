using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.Pay.Blazor.WebAssembly;

[DependsOn(
    typeof(PayBlazorModule),
    typeof(PayHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class PayBlazorWebAssemblyModule : AbpModule
{

}
