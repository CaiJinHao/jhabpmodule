using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public class WorkflowEventAppService
		: CrudApplicationService<WorkflowEvent, WorkflowEventDto, WorkflowEventDto, System.Guid, WorkflowEventRetrieveInputDto, WorkflowEventCreateInputDto, WorkflowEventUpdateInputDto, WorkflowEventDeleteInputDto>,
		IWorkflowEventAppService
	{
		private readonly IWorkflowEventRepository WorkflowEventRepository;
		public WorkflowEventAppService(IWorkflowEventRepository repository) : base(repository)
		{
		WorkflowEventRepository = repository;
		}
	}
}
