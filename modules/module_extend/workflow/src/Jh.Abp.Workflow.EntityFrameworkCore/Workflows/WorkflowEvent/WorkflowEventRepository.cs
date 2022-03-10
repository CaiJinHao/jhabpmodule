using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Jh.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
    public class WorkflowEventRepository : CrudRepository<WorkflowDbContext, WorkflowEvent, System.Guid>, IWorkflowEventRepository
	{
		 public WorkflowEventRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
