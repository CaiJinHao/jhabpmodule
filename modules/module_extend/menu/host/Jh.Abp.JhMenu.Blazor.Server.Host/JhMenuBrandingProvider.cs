using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Jh.Abp.JhMenu.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class JhMenuBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JhMenu";
}
