using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.Workflow;

[Dependency(ReplaceServices = true)]
public class WorkflowBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Workflow";
}
