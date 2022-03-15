using Jh.Abp.Pay.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.Pay.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class PayPageModel : AbpPageModel
{
    protected PayPageModel()
    {
        LocalizationResourceType = typeof(PayResource);
        ObjectMapperContext = typeof(PayWebModule);
    }
}
