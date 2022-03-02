using Jh.Abp.Domain.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowExecutionPointerRepository: ICrudRepository<WorkflowExecutionPointer, System.Guid>
	{
	}
}
