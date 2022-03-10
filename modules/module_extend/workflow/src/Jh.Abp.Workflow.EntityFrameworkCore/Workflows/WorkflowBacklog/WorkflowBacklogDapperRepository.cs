using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
    public class WorkflowBacklogDapperRepository : DapperRepository<WorkflowDbContext>, IWorkflowBacklogDapperRepository, ITransientDependency
	{
		public WorkflowBacklogDapperRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
