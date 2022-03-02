using YourCompany.YourProjectName.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace YourCompany.YourProjectName.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class YourProjectNamePageModel : AbpPageModel
{
    protected YourProjectNamePageModel()
    {
        LocalizationResourceType = typeof(YourProjectNameResource);
        ObjectMapperContext = typeof(YourProjectNameWebModule);
    }
}
