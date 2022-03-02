using Jh.Abp.Domain.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowScheduledCommandRepository: ICrudRepository<WorkflowScheduledCommand, System.Guid>
	{
	}
}
