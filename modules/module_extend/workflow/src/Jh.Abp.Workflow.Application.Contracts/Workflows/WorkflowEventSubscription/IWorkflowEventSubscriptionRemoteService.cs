using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowEventSubscriptionRemoteService
		: IRequestRemoteService<WorkflowEventSubscription, WorkflowEventSubscriptionDto, WorkflowEventSubscriptionDto, System.Guid, WorkflowEventSubscriptionRetrieveInputDto, WorkflowEventSubscriptionCreateInputDto, WorkflowEventSubscriptionUpdateInputDto, WorkflowEventSubscriptionDeleteInputDto>
 , IWorkflowEventSubscriptionBaseAppService
	{
	}
}
