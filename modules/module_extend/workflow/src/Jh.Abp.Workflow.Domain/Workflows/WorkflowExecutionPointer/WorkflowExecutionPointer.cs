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
using Volo.Abp.Domain.Entities;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    [GeneratorClass]
    [Description("执行节点")]
    public class WorkflowExecutionPointer: Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public WorkflowExecutionPointer() { }
        public WorkflowExecutionPointer(Guid id)
        {
            this.Id = id;
        }
        [Required]
        [Description("工作流实例ID")]
        [CreateOrUpdateInputDto]
        public Guid WorkflowInstanceId { get; set; }

        [Required]
        [Description("步骤ID")]
        [CreateOrUpdateInputDto]
        public int StepId { get; set; }

        [Required]
        [Description("是否激活")]
        [CreateOrUpdateInputDto]
        public bool Active { get; set; }

        [Description("SleepUntil")]
        [CreateOrUpdateInputDto]
        public DateTime? SleepUntil { get; set; }

        [Description("PersistenceData")]
        [CreateOrUpdateInputDto]
        public string PersistenceData { get; set; }

        [Description("开始时间")]
        [CreateOrUpdateInputDto]
        public DateTime? StartTime { get; set; }

        [Description("结束时间")]
        [CreateOrUpdateInputDto]
        public DateTime? EndTime { get; set; }

        [MaxLength(100)]
        [Description("事件名称")]
        [CreateOrUpdateInputDto]
        public string EventName { get; set; }

        [MaxLength(100)]
        [Description("EventKey")]
        [CreateOrUpdateInputDto]
        public string EventKey { get; set; }

        [Required]
        [Description("是否事件发布")]
        [CreateOrUpdateInputDto]
        public bool EventPublished { get; set; }

        [Description("事件参数")]
        [CreateOrUpdateInputDto]
        public string EventData { get; set; }

        [MaxLength(100)]
        [Description("步骤名称")]
        [CreateOrUpdateInputDto]
        public string StepName { get; set; }

        [Required]
        [Description("RetryCount")]
        [CreateOrUpdateInputDto]
        public int RetryCount { get; set; }

        [Description("Children")]
        [CreateOrUpdateInputDto]
        public string Children { get; set; }

        [Description("ContextItem")]
        [CreateOrUpdateInputDto]
        public string ContextItem { get; set; }

        [Description("上一步骤ID")]
        [CreateOrUpdateInputDto]
        public Guid? PredecessorId { get; set; }

        [Description("Outcome")]
        [CreateOrUpdateInputDto]
        public string Outcome { get; set; }

        [Required]
        [Description("节点状态")]
        [CreateOrUpdateInputDto]
        public PointerStatus Status { get; set; } = PointerStatus.Legacy;

        [Description("Scope")]
        [CreateOrUpdateInputDto]
        public string Scope { get; set; }

        public WorkflowInstance WorkflowInstance { get; set; }

        public List<WorkflowExtensionAttribute> ExtensionAttributes { get; set; } = new List<WorkflowExtensionAttribute>();
        public void RemoveWorkflowExecutionPointer(WorkflowExtensionAttribute  workflowExtensionAttribute)
        {
            if (workflowExtensionAttribute == null)
                return;
            if (this.ExtensionAttributes != null)
                if (this.ExtensionAttributes.Contains(workflowExtensionAttribute))
                {
                    this.ExtensionAttributes.Remove(workflowExtensionAttribute);
                    workflowExtensionAttribute.ExecutionPointer = null;
                }
        }
    }
}
