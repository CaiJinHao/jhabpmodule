using Jh.Abp.Domain.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowExtensionAttributeRepository: ICrudRepository<WorkflowExtensionAttribute, System.Guid>
	{
	}
}
