using Jh.Abp.JhPermission.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhPermission.Pages;

public abstract class JhPermissionPageModel : AbpPageModel
{
    protected JhPermissionPageModel()
    {
        LocalizationResourceType = typeof(JhPermissionResource);
    }
}
