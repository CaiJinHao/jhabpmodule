using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowBacklogAppService
		: ICrudApplicationService<WorkflowBacklog, WorkflowBacklogDto, WorkflowBacklogDto, System.Guid, WorkflowBacklogRetrieveInputDto, WorkflowBacklogCreateInputDto, WorkflowBacklogUpdateInputDto, WorkflowBacklogDeleteInputDto>
,IWorkflowBacklogBaseAppService
	{
	}
}
