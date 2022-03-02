using Jh.Abp.Workflow.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.Workflow.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class WorkflowPageModel : AbpPageModel
{
    protected WorkflowPageModel()
    {
        LocalizationResourceType = typeof(WorkflowResource);
        ObjectMapperContext = typeof(WorkflowWebModule);
    }
}
