using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.Workflow
{
	public class WorkflowExtensionAttributeRepository : CrudRepository<WorkflowDbContext, WorkflowExtensionAttribute, System.Guid>, IWorkflowExtensionAttributeRepository
	{
		 public WorkflowExtensionAttributeRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
