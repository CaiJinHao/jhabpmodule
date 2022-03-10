using Jh.Abp.Application.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionAppService
		: ICrudApplicationService<WorkflowDefinition, WorkflowDefinitionDto, WorkflowDefinitionDto, System.Guid, WorkflowDefinitionRetrieveInputDto, WorkflowDefinitionCreateInputDto, WorkflowDefinitionUpdateInputDto, WorkflowDefinitionDeleteInputDto>
, IWorkflowDefinitionBaseAppService
	{
		Task<List<WorkflowStepDto>> GetApplicationStepsAsync();
	}
}
