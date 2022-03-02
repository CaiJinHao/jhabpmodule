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
    [GeneratorClass]
    [Description("订阅事件")]
    public class WorkflowEventSubscription : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public WorkflowEventSubscription() { }
        public WorkflowEventSubscription(Guid id) {
            this.Id = id;
        }
        [Required]
        [Description("WorkflowDefinitionId")]
        [CreateOrUpdateInputDto]
        public Guid WorkflowId { get; set; }

        [Required]
        [Description("StepId")]
        [CreateOrUpdateInputDto]
        public int StepId { get; set; }

        [Required]
        [Description("ExecutionPointerId")]
        [CreateOrUpdateInputDto]
        public Guid ExecutionPointerId { get; set; }

        [MaxLength(200)]
        [Description("WorkflowDefinitionId")]
        [CreateOrUpdateInputDto]
        public string EventName { get; set; }

        [MaxLength(200)]
        [Description("WorkflowDefinitionId")]
        [CreateOrUpdateInputDto]
        public string EventKey { get; set; }

        [Description("SubscribeAsOf")]
        [CreateOrUpdateInputDto]
        public DateTime? SubscribeAsOf { get; set; }

        [Description("SubscriptionData")]
        [CreateOrUpdateInputDto]
        public string SubscriptionData { get; set; }

        [MaxLength(200)]
        [Description("SubscriptionData")]
        [CreateOrUpdateInputDto]
        public string ExternalToken { get; set; }

        [MaxLength(200)]
        [Description("ExternalWorkerId")]
        [CreateOrUpdateInputDto]
        public string ExternalWorkerId { get; set; }

        [Description("ExternalTokenExpiry")]
        [CreateOrUpdateInputDto]
        public DateTime? ExternalTokenExpiry { get; set; }
    }
}
