using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
    public class WorkflowBacklogRepository : CrudRepository<WorkflowDbContext, WorkflowBacklog, System.Guid>, IWorkflowBacklogRepository
	{
		 protected readonly IWorkflowBacklogDapperRepository BacklogDapperRepository;
		 public WorkflowBacklogRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider, IWorkflowBacklogDapperRepository backlogDapperRepository) : base(dbContextProvider)
		{
			BacklogDapperRepository=backlogDapperRepository;
		}
	}
}
