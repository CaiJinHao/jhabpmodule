using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public class WorkflowExecutionPointerAppService
		: CrudApplicationService<WorkflowExecutionPointer, WorkflowExecutionPointerDto, WorkflowExecutionPointerDto, System.Guid, WorkflowExecutionPointerRetrieveInputDto, WorkflowExecutionPointerCreateInputDto, WorkflowExecutionPointerUpdateInputDto, WorkflowExecutionPointerDeleteInputDto>,
		IWorkflowExecutionPointerAppService
	{
		private readonly IWorkflowExecutionPointerRepository WorkflowExecutionPointerRepository;
		public WorkflowExecutionPointerAppService(IWorkflowExecutionPointerRepository repository) : base(repository)
		{
		WorkflowExecutionPointerRepository = repository;
		}
	}
}
