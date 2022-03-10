using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowExecutionErrorAppService
		: ICrudApplicationService<WorkflowExecutionError, WorkflowExecutionErrorDto, WorkflowExecutionErrorDto, System.Guid, WorkflowExecutionErrorRetrieveInputDto, WorkflowExecutionErrorCreateInputDto, WorkflowExecutionErrorUpdateInputDto, WorkflowExecutionErrorDeleteInputDto>
,IWorkflowExecutionErrorBaseAppService
	{
	}
}
