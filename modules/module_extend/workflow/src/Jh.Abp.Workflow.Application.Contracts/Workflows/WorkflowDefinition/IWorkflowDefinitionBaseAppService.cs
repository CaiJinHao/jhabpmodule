using System;
using System.Threading.Tasks;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowDefinitionBaseAppService
	{
		Task RecoverAsync(Guid id);
	}
}
