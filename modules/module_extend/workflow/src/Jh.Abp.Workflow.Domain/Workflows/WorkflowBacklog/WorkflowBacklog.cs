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

namespace Jh.Abp.Workflow
{
    [GeneratorClass]
    [Description("待办事项")]
    public class WorkflowBacklog : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public WorkflowBacklog()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">WorkflowExecutionPointerId</param>
        public WorkflowBacklog(Guid id)
        {
            Id = id;
        }
        public WorkflowBacklog(Guid id, Guid? creatorId)
        {
            Id = id;
            CreatorId = creatorId;
        }
        public virtual Guid? TenantId { get; set; }

        [Required]
        [Description("WorkflowInstanceId")]
        [CreateOrUpdateInputDto]
        public Guid WorkflowInstanceId { get; set; }

        [Description("待办人")]
        [CreateOrUpdateInputDto]
        public Guid BacklogUserId { get; set; }

        [Description("待办人名称")]
        [CreateOrUpdateInputDto]
        public string BacklogUserName { get; set; }

        [Description("办理时间")]
        [CreateOrUpdateInputDto]
        public DateTime? BacklogHandleTime { get; set; }

        /// <summary>
        /// 通过、不通过、流转、超时自动流转
        /// </summary>
        [Required]
        [Description("办理结果")]
        [CreateOrUpdateInputDto]
        public BacklogResultType BacklogResult { get; set; }

        [Description("办理结果备注")]
        [CreateOrUpdateInputDto]
        public string BacklogRemark { get; set; }
    }
}
