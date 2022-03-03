using Volo.Abp.Bundling;

namespace Jh.Abp.JhPermission.Blazor.Host;

public class JhPermissionBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
