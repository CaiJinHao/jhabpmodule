using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowScheduledCommandAppService
		: ICrudApplicationService<WorkflowScheduledCommand, WorkflowScheduledCommandDto, WorkflowScheduledCommandDto, System.Guid, WorkflowScheduledCommandRetrieveInputDto, WorkflowScheduledCommandCreateInputDto, WorkflowScheduledCommandUpdateInputDto, WorkflowScheduledCommandDeleteInputDto>
,IWorkflowScheduledCommandBaseAppService
	{
	}
}
