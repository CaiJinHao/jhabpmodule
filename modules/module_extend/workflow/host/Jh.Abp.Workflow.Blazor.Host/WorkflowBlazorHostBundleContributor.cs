using Volo.Abp.Bundling;

namespace Jh.Abp.Workflow.Blazor.Host;

public class WorkflowBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
