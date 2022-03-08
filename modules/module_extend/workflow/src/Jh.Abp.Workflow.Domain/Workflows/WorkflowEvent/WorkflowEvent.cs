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

namespace Jh.Abp.Workflow
{
    
    [Description("事件")]
    public class WorkflowEvent : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public WorkflowEvent() { }
        public WorkflowEvent(Guid id) {
            this.Id= id;
        }
        [Required]
        [MaxLength(200)]
        [Description("事件名称")]
        [CreateOrUpdateInputDto]
        public string EventName { get; set; }

        [Required]
        [MaxLength(200)]
        [Description("事件Key")]
        [CreateOrUpdateInputDto]
        public string EventKey { get; set; }

        [Description("事件参数")]
        [CreateOrUpdateInputDto]
        public string EventData { get; set; }

        [Required]
        [Description("事件是否处理")]
        [CreateOrUpdateInputDto]
        public bool IsProcessed { get; set; }

        [Description("事件时间")]
        [CreateOrUpdateInputDto]
        public DateTime EventTime { get; set; }
    }
}
