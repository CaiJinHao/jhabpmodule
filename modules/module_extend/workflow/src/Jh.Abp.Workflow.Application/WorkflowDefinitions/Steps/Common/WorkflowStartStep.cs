using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 发起流程，所有流程的开始
    /// </summary>
    [NotShowStep]
    [Description("发起流程")]
    public class WorkflowStartStep : StepBase, ITransientDependency
    {
        /// <summary>
        /// 流程业务数据ID
        /// </summary>
        public string BusinessDataId { get; set; }

        public override ExecutionResult ExecutionRun(IStepExecutionContext context)
        {
            //将业务数据ID更新到实例
            workflowInstanceId = new Guid(context.Workflow.Id);
            UpdateWorkflowInstance().Wait();
            return ExecutionResult.Next();
        }

        private async Task UpdateWorkflowInstance()
        {
            var workflowInstanceEntity = await workflowInstanceRepository.FindAsync(workflowInstanceId);
            var workflowDef = await workflowDefinitionRepository.FindAsync(workflowDefinitionId);
            workflowInstanceEntity.BusinessDataId = BusinessDataId;
            workflowInstanceEntity.BusinessType = workflowDef.BusinessType;
        }
    }
}

/*
发布流程data
{
  "id":"3a01eab1-42f6-33e9-4dbf-9e8d97e3bb03",
  "data": {
      "BusinessDataId": "1234567984561646fsxxxx",
      "Day":3
   }
}
 */
