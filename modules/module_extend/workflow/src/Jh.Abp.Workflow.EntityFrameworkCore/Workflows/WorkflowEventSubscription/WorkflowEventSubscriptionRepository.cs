using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
	public class WorkflowEventSubscriptionRepository : CrudRepository<WorkflowDbContext, WorkflowEventSubscription, System.Guid>, IWorkflowEventSubscriptionRepository
	{
		 public WorkflowEventSubscriptionRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
