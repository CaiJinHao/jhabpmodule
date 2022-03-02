using Jh.Abp.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
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
