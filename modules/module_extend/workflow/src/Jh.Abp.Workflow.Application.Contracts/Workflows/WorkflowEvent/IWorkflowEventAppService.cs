using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowEventAppService
		: ICrudApplicationService<WorkflowEvent, WorkflowEventDto, WorkflowEventDto, System.Guid, WorkflowEventRetrieveInputDto, WorkflowEventCreateInputDto, WorkflowEventUpdateInputDto, WorkflowEventDeleteInputDto>
,IWorkflowEventBaseAppService
	{
	}
}
