using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public class WorkflowEventSubscriptionAppService
		: CrudApplicationService<WorkflowEventSubscription, WorkflowEventSubscriptionDto, WorkflowEventSubscriptionDto, System.Guid, WorkflowEventSubscriptionRetrieveInputDto, WorkflowEventSubscriptionCreateInputDto, WorkflowEventSubscriptionUpdateInputDto, WorkflowEventSubscriptionDeleteInputDto>,
		IWorkflowEventSubscriptionAppService
	{
		private readonly IWorkflowEventSubscriptionRepository WorkflowEventSubscriptionRepository;
		public WorkflowEventSubscriptionAppService(IWorkflowEventSubscriptionRepository repository) : base(repository)
		{
		WorkflowEventSubscriptionRepository = repository;
		}
	}
}
