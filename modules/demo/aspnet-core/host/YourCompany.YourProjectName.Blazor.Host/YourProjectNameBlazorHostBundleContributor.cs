using Volo.Abp.Bundling;

namespace YourCompany.YourProjectName.Blazor.Host;

public class YourProjectNameBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
