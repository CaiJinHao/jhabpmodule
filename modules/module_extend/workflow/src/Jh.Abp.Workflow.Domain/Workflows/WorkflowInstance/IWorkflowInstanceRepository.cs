using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowInstanceRepository: ICrudRepository<WorkflowInstance, System.Guid>
	{
		Task<IEnumerable<WorkflowCore.Models.WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type, DateTime? createdFrom, DateTime? createdTo, int skip, int take);
		Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken cancellationToken = default);
		Task<IEnumerable<WorkflowCore.Models.WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids, CancellationToken cancellationToken = default);
		Task PersistWorkflow(WorkflowCore.Models.WorkflowInstance workflow, CancellationToken cancellationToken = default);
	}
}
