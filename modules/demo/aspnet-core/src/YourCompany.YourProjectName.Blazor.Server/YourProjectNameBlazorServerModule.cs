using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(YourProjectNameBlazorModule)
    )]
public class YourProjectNameBlazorServerModule : AbpModule
{

}
