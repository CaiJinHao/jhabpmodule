using Jh.Abp.Domain.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowExecutionErrorRepository: ICrudRepository<WorkflowExecutionError, System.Guid>
	{
	}
}
