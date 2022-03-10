using Jh.Abp.Application.Contracts;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowBacklogAppService
		: ICrudApplicationService<WorkflowBacklog, WorkflowBacklogDto, WorkflowBacklogDto, System.Guid, WorkflowBacklogRetrieveInputDto, WorkflowBacklogCreateInputDto, WorkflowBacklogUpdateInputDto, WorkflowBacklogDeleteInputDto>
,IWorkflowBacklogBaseAppService
	{
	}
}
