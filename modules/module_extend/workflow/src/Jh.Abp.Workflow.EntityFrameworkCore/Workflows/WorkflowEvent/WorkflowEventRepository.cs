using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
	public class WorkflowEventRepository : CrudRepository<WorkflowDbContext, WorkflowEvent, System.Guid>, IWorkflowEventRepository
	{
		 public WorkflowEventRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
