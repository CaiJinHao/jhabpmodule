using Jh.Abp.Workflow.Localization;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Workflow;

public abstract class WorkflowAppService : ApplicationService
{
    protected WorkflowAppService()
    {
        LocalizationResource = typeof(WorkflowResource);
        ObjectMapperContext = typeof(WorkflowApplicationModule);
    }
}
