using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.JhIdentity.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(JhIdentityBlazorModule)
    )]
public class JhIdentityBlazorServerModule : AbpModule
{

}
