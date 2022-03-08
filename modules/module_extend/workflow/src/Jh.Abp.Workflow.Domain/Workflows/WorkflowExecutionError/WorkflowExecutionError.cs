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
    
    [Description("执行错误")]
    public class WorkflowExecutionError : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        [Required]
        [Description("工作流ID")]
        [CreateOrUpdateInputDto]
        public Guid WorkflowId { get; set; }

        [Required]
        [Description("执行节点ID")]
        [CreateOrUpdateInputDto]
        public Guid ExecutionPointerId { get; set; }

        [Description("错误信息")]
        [CreateOrUpdateInputDto]
        public string Message { get; set; }
    }
}
