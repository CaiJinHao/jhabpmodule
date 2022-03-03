using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission.Blazor.WebAssembly;

[DependsOn(
    typeof(JhPermissionBlazorModule),
    typeof(JhPermissionHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class JhPermissionBlazorWebAssemblyModule : AbpModule
{

}
