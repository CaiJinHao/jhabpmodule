using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhPermission.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(JhPermissionBlazorModule)
    )]
public class JhPermissionBlazorServerModule : AbpModule
{

}
