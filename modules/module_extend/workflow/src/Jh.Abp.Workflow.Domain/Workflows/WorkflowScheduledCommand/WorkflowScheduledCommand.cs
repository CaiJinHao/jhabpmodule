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
    
    public class WorkflowScheduledCommand:CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        [Required]
        [MaxLength(200)]
        [Description("命令名称")]
        [CreateOrUpdateInputDto]
        public string CommandName { get; set; }

        [Description("参数")]
        [CreateOrUpdateInputDto]
        public string Data { get; set; }

        public long ExecuteTime { get; set; }
    }
}
