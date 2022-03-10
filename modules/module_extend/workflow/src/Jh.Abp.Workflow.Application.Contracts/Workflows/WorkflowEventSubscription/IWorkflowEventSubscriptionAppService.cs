using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowEventSubscriptionAppService
		: ICrudApplicationService<WorkflowEventSubscription, WorkflowEventSubscriptionDto, WorkflowEventSubscriptionDto, System.Guid, WorkflowEventSubscriptionRetrieveInputDto, WorkflowEventSubscriptionCreateInputDto, WorkflowEventSubscriptionUpdateInputDto, WorkflowEventSubscriptionDeleteInputDto>
,IWorkflowEventSubscriptionBaseAppService
	{
	}
}
