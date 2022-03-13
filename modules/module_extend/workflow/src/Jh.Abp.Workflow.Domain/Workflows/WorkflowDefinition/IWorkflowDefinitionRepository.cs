using Jh.Abp.Domain;
using System;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionRepository: ICrudRepository<WorkflowDefinition, System.Guid>
	{
		Task LoadWorkflowDefinitionByIdAsync(Guid id);
		Task LoadWorkflowDefinitionAllAsync();
		Task<WorkflowCore.Models.WorkflowDefinition> LoadWorkflowDefinitionByFileAsync(string virtualFilePath);
		Task<WorkflowCore.Models.WorkflowDefinition> LoadWorkflowDefinitionAsync(WorkflowDefinition data);
	}
}
