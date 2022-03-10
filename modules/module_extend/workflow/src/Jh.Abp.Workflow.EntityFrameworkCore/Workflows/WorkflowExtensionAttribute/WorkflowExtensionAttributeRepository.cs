using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Jh.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
    public class WorkflowExtensionAttributeRepository : CrudRepository<WorkflowDbContext, WorkflowExtensionAttribute, System.Guid>, IWorkflowExtensionAttributeRepository
	{
		 public WorkflowExtensionAttributeRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
