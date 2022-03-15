using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.Pay.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(PayBlazorModule)
    )]
public class PayBlazorServerModule : AbpModule
{

}
