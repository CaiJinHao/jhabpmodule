using Jh.Abp.Workflow.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.Workflow;

public abstract class WorkflowController : AbpControllerBase
{
    protected WorkflowController()
    {
        LocalizationResource = typeof(WorkflowResource);
    }
}
