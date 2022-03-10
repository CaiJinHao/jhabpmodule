using Jh.Abp.Domain;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowEventSubscriptionRepository: ICrudRepository<WorkflowEventSubscription, System.Guid>
	{
	}
}
