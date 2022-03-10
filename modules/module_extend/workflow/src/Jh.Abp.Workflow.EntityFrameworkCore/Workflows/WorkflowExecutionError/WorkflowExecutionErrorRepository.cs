using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
    public class WorkflowExecutionErrorRepository : CrudRepository<WorkflowDbContext, WorkflowExecutionError, System.Guid>, IWorkflowExecutionErrorRepository
	{
		 public WorkflowExecutionErrorRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
