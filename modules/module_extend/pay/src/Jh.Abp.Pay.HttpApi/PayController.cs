using Jh.Abp.Pay.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.Pay;

public abstract class PayController : AbpControllerBase
{
    protected PayController()
    {
        LocalizationResource = typeof(PayResource);
    }
}
