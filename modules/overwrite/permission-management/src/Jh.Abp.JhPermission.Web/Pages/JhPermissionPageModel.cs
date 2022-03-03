using Jh.Abp.JhPermission.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhPermission.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class JhPermissionPageModel : AbpPageModel
{
    protected JhPermissionPageModel()
    {
        LocalizationResourceType = typeof(JhPermissionResource);
        ObjectMapperContext = typeof(JhPermissionWebModule);
    }
}
