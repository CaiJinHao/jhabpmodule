using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowExecutionPointerRemoteService
		: IRequestRemoteService<WorkflowExecutionPointer, WorkflowExecutionPointerDto, WorkflowExecutionPointerDto, System.Guid, WorkflowExecutionPointerRetrieveInputDto, WorkflowExecutionPointerCreateInputDto, WorkflowExecutionPointerUpdateInputDto, WorkflowExecutionPointerDeleteInputDto>
 , IWorkflowExecutionPointerBaseAppService
	{
	}
}
