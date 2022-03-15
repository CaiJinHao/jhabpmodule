using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.Pay;

[Dependency(ReplaceServices = true)]
public class PayBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Pay";
}
