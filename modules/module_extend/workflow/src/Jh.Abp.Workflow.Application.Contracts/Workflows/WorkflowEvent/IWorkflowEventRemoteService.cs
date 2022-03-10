using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowEventRemoteService
		: IRequestRemoteService<WorkflowEvent, WorkflowEventDto, WorkflowEventDto, System.Guid, WorkflowEventRetrieveInputDto, WorkflowEventCreateInputDto, WorkflowEventUpdateInputDto, WorkflowEventDeleteInputDto>
 , IWorkflowEventBaseAppService
	{
	}
}
