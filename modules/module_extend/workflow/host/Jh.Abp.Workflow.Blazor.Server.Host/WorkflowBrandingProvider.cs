using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Jh.Abp.Workflow.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class WorkflowBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Workflow";
}
