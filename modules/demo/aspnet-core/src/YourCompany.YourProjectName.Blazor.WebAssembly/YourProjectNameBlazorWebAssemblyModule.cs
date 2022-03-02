using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName.Blazor.WebAssembly;

[DependsOn(
    typeof(YourProjectNameBlazorModule),
    typeof(YourProjectNameHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class YourProjectNameBlazorWebAssemblyModule : AbpModule
{

}
