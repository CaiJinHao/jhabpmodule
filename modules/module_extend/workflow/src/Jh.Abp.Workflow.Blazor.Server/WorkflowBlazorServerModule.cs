using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(WorkflowBlazorModule)
    )]
public class WorkflowBlazorServerModule : AbpModule
{

}
