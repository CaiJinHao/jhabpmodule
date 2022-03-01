using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu.Blazor.WebAssembly;

[DependsOn(
    typeof(JhMenuBlazorModule),
    typeof(JhMenuHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class JhMenuBlazorWebAssemblyModule : AbpModule
{

}
