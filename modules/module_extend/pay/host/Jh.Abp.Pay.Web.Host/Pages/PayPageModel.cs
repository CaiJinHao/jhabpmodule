using Jh.Abp.Pay.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.Pay.Pages;

public abstract class PayPageModel : AbpPageModel
{
    protected PayPageModel()
    {
        LocalizationResourceType = typeof(PayResource);
    }
}
