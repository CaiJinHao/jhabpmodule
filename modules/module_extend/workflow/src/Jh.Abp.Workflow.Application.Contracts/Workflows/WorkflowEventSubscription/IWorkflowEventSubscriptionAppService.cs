using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowEventSubscriptionAppService
		: ICrudApplicationService<WorkflowEventSubscription, WorkflowEventSubscriptionDto, WorkflowEventSubscriptionDto, System.Guid, WorkflowEventSubscriptionRetrieveInputDto, WorkflowEventSubscriptionCreateInputDto, WorkflowEventSubscriptionUpdateInputDto, WorkflowEventSubscriptionDeleteInputDto>
,IWorkflowEventSubscriptionBaseAppService
	{
	}
}
