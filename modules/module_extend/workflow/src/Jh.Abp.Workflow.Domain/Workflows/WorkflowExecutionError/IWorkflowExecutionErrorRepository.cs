using Jh.Abp.Domain;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowExecutionErrorRepository: ICrudRepository<WorkflowExecutionError, System.Guid>
	{
	}
}
