using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhIdentity.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class JhIdentityPageModel : AbpPageModel
{
    protected JhIdentityPageModel()
    {
        LocalizationResourceType = typeof(JhIdentityResource);
        ObjectMapperContext = typeof(JhIdentityWebModule);
    }
}
