using Jh.Abp.JhMenu.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhMenu.Pages;

public abstract class JhMenuPageModel : AbpPageModel
{
    protected JhMenuPageModel()
    {
        LocalizationResourceType = typeof(JhMenuResource);
    }
}
