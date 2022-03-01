using Volo.Abp.Bundling;

namespace Jh.Abp.JhMenu.Blazor.Host;

public class JhMenuBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
