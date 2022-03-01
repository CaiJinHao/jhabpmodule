using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.JhMenu;

[Dependency(ReplaceServices = true)]
public class JhMenuBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JhMenu";
}
