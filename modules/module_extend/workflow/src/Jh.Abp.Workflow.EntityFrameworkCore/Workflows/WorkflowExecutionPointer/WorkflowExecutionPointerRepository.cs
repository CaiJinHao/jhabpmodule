using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
	public class WorkflowExecutionPointerRepository : CrudRepository<WorkflowDbContext, WorkflowExecutionPointer, System.Guid>, IWorkflowExecutionPointerRepository
	{
		 public WorkflowExecutionPointerRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
