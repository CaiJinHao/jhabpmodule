using Jh.Abp.Domain.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowBacklogRepository: ICrudRepository<WorkflowBacklog, System.Guid>
	{
	}
}