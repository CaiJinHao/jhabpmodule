using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public class WorkflowScheduledCommandAppService
		: CrudApplicationService<WorkflowScheduledCommand, WorkflowScheduledCommandDto, WorkflowScheduledCommandDto, System.Guid, WorkflowScheduledCommandRetrieveInputDto, WorkflowScheduledCommandCreateInputDto, WorkflowScheduledCommandUpdateInputDto, WorkflowScheduledCommandDeleteInputDto>,
		IWorkflowScheduledCommandAppService
	{
		private readonly IWorkflowScheduledCommandRepository WorkflowScheduledCommandRepository;
		public WorkflowScheduledCommandAppService(IWorkflowScheduledCommandRepository repository) : base(repository)
		{
		WorkflowScheduledCommandRepository = repository;
		}
	}
}
