using Volo.Abp.Bundling;

namespace Jh.Abp.Pay.Blazor.Host;

public class PayBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
