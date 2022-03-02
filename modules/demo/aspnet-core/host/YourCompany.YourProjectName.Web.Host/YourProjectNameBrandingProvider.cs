using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace YourCompany.YourProjectName;

[Dependency(ReplaceServices = true)]
public class YourProjectNameBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "YourProjectName";
}
