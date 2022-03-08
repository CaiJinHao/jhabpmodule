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

namespace Jh.Abp.Workflow
{
    
    [Description("扩展属性")]
    public class WorkflowExtensionAttribute:CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        [Required]
        [Description("ExecutionPointerId")]
        [CreateOrUpdateInputDto]
        public Guid ExecutionPointerId { get; set; }

        [MaxLength(100)]
        [Description("AttributeKey")]
        [CreateOrUpdateInputDto]
        public string AttributeKey { get; set; }

        [Description("AttributeValue")]
        [CreateOrUpdateInputDto]
        public string AttributeValue { get; set; }

        public WorkflowExecutionPointer ExecutionPointer { get; set; }
    }
}
