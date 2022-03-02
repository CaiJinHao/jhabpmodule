using Jh.Abp.Workflow.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.Workflow.Pages;

public abstract class WorkflowPageModel : AbpPageModel
{
    protected WorkflowPageModel()
    {
        LocalizationResourceType = typeof(WorkflowResource);
    }
}
