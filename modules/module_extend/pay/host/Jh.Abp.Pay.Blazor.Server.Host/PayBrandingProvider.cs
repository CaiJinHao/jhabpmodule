using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Jh.Abp.Pay.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class PayBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Pay";
}
