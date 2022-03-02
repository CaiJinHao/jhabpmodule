using Jh.Abp.Extensions;
using System;
using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowScheduledCommandRemoteService
		: IRequestRemoteService<WorkflowScheduledCommand, WorkflowScheduledCommandDto, WorkflowScheduledCommandDto, System.Guid, WorkflowScheduledCommandRetrieveInputDto, WorkflowScheduledCommandCreateInputDto, WorkflowScheduledCommandUpdateInputDto, WorkflowScheduledCommandDeleteInputDto>
 , IWorkflowScheduledCommandBaseAppService
	{
	}
}
