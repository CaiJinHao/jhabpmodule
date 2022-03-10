using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowExecutionPointerAppService
		: ICrudApplicationService<WorkflowExecutionPointer, WorkflowExecutionPointerDto, WorkflowExecutionPointerDto, System.Guid, WorkflowExecutionPointerRetrieveInputDto, WorkflowExecutionPointerCreateInputDto, WorkflowExecutionPointerUpdateInputDto, WorkflowExecutionPointerDeleteInputDto>
,IWorkflowExecutionPointerBaseAppService
	{
	}
}
