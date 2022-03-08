using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Jh.SourceGenerator.Common.GeneratorAttributes;
using Volo.Abp;
using JetBrains.Annotations;
using System.Linq;
using Volo.Abp.MultiTenancy;
using Jh.Abp.Common;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    
    [Description("工作流实例")]
    public class WorkflowInstance : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public WorkflowInstance() { }
        public WorkflowInstance(Guid id)
        {
            this.Id = id;
        }

        [Description("WorkflowDefinitionId")]
        [CreateOrUpdateInputDto]
        public string WorkflowDefinitionId { get; set; }

        [Required]
        [Description("WorkflowDefinitionId")]
        [CreateOrUpdateInputDto]
        public int Version { get; set; }

        [Description("Description")]
        [CreateOrUpdateInputDto]
        public string Description { get; set; }

        [Description("Reference")]
        [CreateOrUpdateInputDto]
        public string Reference { get; set; }

        [Description("NextExecution")]
        [CreateOrUpdateInputDto]
        public long? NextExecution { get; set; }

        [Description("Data")]
        [CreateOrUpdateInputDto]
        public string Data { get; set; }

        [Description("CompleteTime")]
        [CreateOrUpdateInputDto]
        public DateTime? CompleteTime { get; set; }

        [Required]
        [Description("Status")]
        [CreateOrUpdateInputDto]
        public WorkflowStatus Status { get; set; }

        /// <summary>
        /// 业务系统需要根据业务类型做映射找对应的页面
        /// </summary>
        [Description("业务类型")]
        [CreateOrUpdateInputDto]
        public int? BusinessType { get; set; }

        /// <summary>
        /// 业务系统拿着数据ID去请求详情页面
        /// </summary>
        [Description("业务数据ID")]
        [CreateOrUpdateInputDto]
        public string BusinessDataId { get; set; }

        public virtual List<WorkflowExecutionPointer> ExecutionPointers { get; set; }=new List<WorkflowExecutionPointer>();
        public void RemoveWorkflowExecutionPointer(WorkflowExecutionPointer workflowExecutionPointer)
        {
            if (workflowExecutionPointer == null)
                return;
            if (this.ExecutionPointers != null)
                if (this.ExecutionPointers.Contains(workflowExecutionPointer))
                {
                    this.ExecutionPointers.Remove(workflowExecutionPointer);
                    workflowExecutionPointer.WorkflowInstance = null;
                }
        }
    }
}
