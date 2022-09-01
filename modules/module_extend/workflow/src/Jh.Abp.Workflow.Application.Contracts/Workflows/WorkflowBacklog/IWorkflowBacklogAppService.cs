using Jh.Abp.Application.Contracts;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowBacklogAppService
		: ICrudApplicationService<WorkflowBacklogDto, WorkflowBacklogDto, System.Guid, WorkflowBacklogRetrieveInputDto, WorkflowBacklogCreateInputDto, WorkflowBacklogUpdateInputDto, WorkflowBacklogDeleteInputDto>
	{
	}
}
