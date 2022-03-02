using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Dapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowBacklogDapperRepository : DapperRepository<WorkflowDbContext>, IWorkflowBacklogDapperRepository, ITransientDependency
	{
		public WorkflowBacklogDapperRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
