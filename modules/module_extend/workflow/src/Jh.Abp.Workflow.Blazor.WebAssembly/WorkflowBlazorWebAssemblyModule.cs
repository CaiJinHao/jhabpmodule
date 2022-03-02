using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow.Blazor.WebAssembly;

[DependsOn(
    typeof(WorkflowBlazorModule),
    typeof(WorkflowHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class WorkflowBlazorWebAssemblyModule : AbpModule
{

}
