using Volo.Abp.Bundling;

namespace Jh.Abp.JhIdentity.Blazor.Host;

public class JhIdentityBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
