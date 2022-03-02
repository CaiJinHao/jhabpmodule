using Jh.Abp.Extensions;
using System;
using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowInstanceRemoteService
		: IRequestRemoteService<WorkflowInstance, WorkflowInstanceDto, WorkflowInstanceDto, System.Guid, WorkflowInstanceRetrieveInputDto, WorkflowInstanceCreateInputDto, WorkflowInstanceUpdateInputDto, WorkflowInstanceDeleteInputDto>
 , IWorkflowInstanceBaseAppService
	{
	}
}
