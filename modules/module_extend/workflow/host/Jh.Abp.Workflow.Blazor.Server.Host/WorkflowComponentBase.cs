using Jh.Abp.Workflow.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Jh.Abp.Workflow.Blazor.Server.Host;

public abstract class WorkflowComponentBase : AbpComponentBase
{
    protected WorkflowComponentBase()
    {
        LocalizationResource = typeof(WorkflowResource);
    }
}
