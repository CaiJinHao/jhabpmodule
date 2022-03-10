using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.Workflow.EntityFrameworkCore;
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
