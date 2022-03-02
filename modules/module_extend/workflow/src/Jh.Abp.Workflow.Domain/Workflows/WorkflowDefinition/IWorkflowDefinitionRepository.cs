using Jh.Abp.Domain.Extensions;
using System;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
	public interface IWorkflowDefinitionRepository: ICrudRepository<WorkflowDefinition, System.Guid>
	{
		Task LoadWorkflowDefinitionAsync();
		WorkflowCore.Models.WorkflowDefinition LoadWorkflowDefinition(WorkflowDefinition data);
	}
}
