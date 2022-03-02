using Jh.Abp.Extensions;
using System;
using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowExecutionErrorRemoteService
		: IRequestRemoteService<WorkflowExecutionError, WorkflowExecutionErrorDto, WorkflowExecutionErrorDto, System.Guid, WorkflowExecutionErrorRetrieveInputDto, WorkflowExecutionErrorCreateInputDto, WorkflowExecutionErrorUpdateInputDto, WorkflowExecutionErrorDeleteInputDto>
 , IWorkflowExecutionErrorBaseAppService
	{
	}
}
