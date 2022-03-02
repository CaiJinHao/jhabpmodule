using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    public class WorkflowPurger : IWorkflowPurger, ITransientDependency
    {
        public IWorkflowInstanceRepository workflowInstanceRepository { get; set; }

        public async Task PurgeWorkflows(WorkflowStatus status, DateTime olderThan, CancellationToken cancellationToken = default)
        {
            var olderThanUtc = olderThan.ToUniversalTime();
            var workflows = await (await workflowInstanceRepository.GetQueryableAsync(true)).Where(x => x.Status == status && x.CompleteTime < olderThanUtc).ToListAsync(cancellationToken);
            foreach (var wf in workflows)
            {
                foreach (var pointer in wf.ExecutionPointers)
                {
                    foreach (var extAttr in pointer.ExtensionAttributes)
                    {
                        pointer.RemoveWorkflowExecutionPointer(extAttr);
                    }
                    wf.RemoveWorkflowExecutionPointer(pointer);
                }
                await workflowInstanceRepository.DeleteAsync(wf);
            }
        }
    }
}
