using Jh.Abp.Domain.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowEventRepository: ICrudRepository<WorkflowEvent, System.Guid>
	{
	}
}
