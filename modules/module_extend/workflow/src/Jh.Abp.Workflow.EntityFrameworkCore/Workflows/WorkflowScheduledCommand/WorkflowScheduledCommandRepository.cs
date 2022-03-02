using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
	public class WorkflowScheduledCommandRepository : CrudRepository<WorkflowDbContext, WorkflowScheduledCommand, System.Guid>, IWorkflowScheduledCommandRepository
	{
		 public WorkflowScheduledCommandRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
