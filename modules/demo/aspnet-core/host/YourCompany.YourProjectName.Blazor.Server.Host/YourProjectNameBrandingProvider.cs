using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace YourCompany.YourProjectName.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class YourProjectNameBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "YourProjectName";
}
