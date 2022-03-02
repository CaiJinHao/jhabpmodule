using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public class WorkflowExecutionErrorAppService
		: CrudApplicationService<WorkflowExecutionError, WorkflowExecutionErrorDto, WorkflowExecutionErrorDto, System.Guid, WorkflowExecutionErrorRetrieveInputDto, WorkflowExecutionErrorCreateInputDto, WorkflowExecutionErrorUpdateInputDto, WorkflowExecutionErrorDeleteInputDto>,
		IWorkflowExecutionErrorAppService
	{
		private readonly IWorkflowExecutionErrorRepository WorkflowExecutionErrorRepository;
		public WorkflowExecutionErrorAppService(IWorkflowExecutionErrorRepository repository) : base(repository)
		{
		WorkflowExecutionErrorRepository = repository;
		}
	}
}
