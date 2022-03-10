using Jh.Abp.Domain;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionRepository: ICrudRepository<WorkflowDefinition, System.Guid>
	{
		Task LoadWorkflowDefinitionAsync();
		Task<WorkflowCore.Models.WorkflowDefinition> LoadWorkflowDefinitionAsync(string virtualFilePath);

		WorkflowCore.Models.WorkflowDefinition LoadWorkflowDefinition(WorkflowDefinition data);
	}
}
