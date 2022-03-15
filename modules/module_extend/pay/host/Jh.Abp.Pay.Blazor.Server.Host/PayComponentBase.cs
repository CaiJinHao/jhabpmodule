using Jh.Abp.Pay.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Jh.Abp.Pay.Blazor.Server.Host;

public abstract class PayComponentBase : AbpComponentBase
{
    protected PayComponentBase()
    {
        LocalizationResource = typeof(PayResource);
    }
}
