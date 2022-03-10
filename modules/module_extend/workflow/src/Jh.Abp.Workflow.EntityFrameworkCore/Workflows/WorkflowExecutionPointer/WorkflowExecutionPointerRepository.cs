using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.Workflow.EntityFrameworkCore;
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
