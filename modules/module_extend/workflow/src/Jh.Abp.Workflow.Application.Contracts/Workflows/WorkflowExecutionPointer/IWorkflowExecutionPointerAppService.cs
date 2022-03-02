using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowExecutionPointerAppService
		: ICrudApplicationService<WorkflowExecutionPointer, WorkflowExecutionPointerDto, WorkflowExecutionPointerDto, System.Guid, WorkflowExecutionPointerRetrieveInputDto, WorkflowExecutionPointerCreateInputDto, WorkflowExecutionPointerUpdateInputDto, WorkflowExecutionPointerDeleteInputDto>
,IWorkflowExecutionPointerBaseAppService
	{
	}
}
