using Jh.Abp.JhMenu.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhMenu.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class JhMenuPageModel : AbpPageModel
{
    protected JhMenuPageModel()
    {
        LocalizationResourceType = typeof(JhMenuResource);
        ObjectMapperContext = typeof(JhMenuWebModule);
    }
}
