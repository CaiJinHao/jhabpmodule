using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhMenu.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(JhMenuBlazorModule)
    )]
public class JhMenuBlazorServerModule : AbpModule
{

}
