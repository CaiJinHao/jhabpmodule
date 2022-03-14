using Jh.Abp.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionAppService
		: ICrudApplicationService<WorkflowDefinition, WorkflowDefinitionDto, WorkflowDefinitionDto, System.Guid, WorkflowDefinitionRetrieveInputDto, WorkflowDefinitionCreateInputDto, WorkflowDefinitionUpdateInputDto, WorkflowDefinitionDeleteInputDto>
	{
		Task RecoverAsync(Guid id);
		Task<ListResultDto<WorkflowStepDto>> GetApplicationStepsAsync();
	}
}
