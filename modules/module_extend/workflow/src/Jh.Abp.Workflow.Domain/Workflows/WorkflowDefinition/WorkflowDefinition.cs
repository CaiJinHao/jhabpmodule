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
    
    [Description("工作流定义")]
    public class WorkflowDefinition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public WorkflowDefinition() { }
        public WorkflowDefinition(Guid id) {
            Id= id;
        }
        public virtual Guid? TenantId { get; set; }

        [Required]
        [Description("版本")]
        [CreateOrUpdateInputDto]
        public int Version { get; set; }

        [Description("描述")]
        [CreateOrUpdateInputDto]
        public string Description { get; set; }

        /// <summary>
        /// 注意 Json里面的id要和实体Id保持大小写一致，建议使用小写
        /// </summary>
        [Description("流程JSON定义")]
        [CreateOrUpdateInputDto]
        public string JsonDefinition { get; set; }

        /// <summary>
        /// 格式映射DynamicData
        /// </summary>
        [Description("流程输入数据")]
        [CreateOrUpdateInputDto]
        public string InputData { get; set; }

        [Description("流程表单定义HTML")]
        [CreateOrUpdateInputDto]
        public string FormDefinition { get; set; }

        /// <summary>
        /// 用于匹配业务
        /// </summary>
        [Required]
        [Description("业务类型")]
        [CreateOrUpdateInputDto]
        public int BusinessType { get; set; }
    }
}
