using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    public interface IJhWorkflowHost : IWorkflowHost
    {
        bool IsRegistered(string workflowId, int version);
        Task WaitForWorkflowToCompleteAsync(string workflowId, TimeSpan timeOut);
        Task<WorkflowStatus> GetStatusAsync(string workflowId);
        Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceAsync(string workflowId);
    }
}
