using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionRemoteService
		: IRequestRemoteService<WorkflowDefinition, WorkflowDefinitionDto, WorkflowDefinitionDto, System.Guid, WorkflowDefinitionRetrieveInputDto, WorkflowDefinitionCreateInputDto, WorkflowDefinitionUpdateInputDto, WorkflowDefinitionDeleteInputDto>
 , IWorkflowDefinitionBaseAppService
	{
	}
}
