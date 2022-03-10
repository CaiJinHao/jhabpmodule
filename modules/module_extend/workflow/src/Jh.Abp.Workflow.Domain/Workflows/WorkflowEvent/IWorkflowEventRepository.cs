using Jh.Abp.Domain;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowEventRepository: ICrudRepository<WorkflowEvent, System.Guid>
	{
	}
}
