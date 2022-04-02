using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 工作流定义
    /// </summary>
    public class WorkflowDefinitionUpdateInputDto: 
ExtensibleObject,
IHasConcurrencyStamp,
IMethodDto<WorkflowDefinition>
	{
		/// <summary>
		/// 版本
		/// </summary>
		public Int32? Version { get; set; }
		/// <summary>
		/// 描述
		/// </summary>
		public String Description { get; set; }
		/// <summary>
		/// JsonDefinition
		/// </summary>
		public string JsonDefinition { get; set; }
		/// <summary>
		/// 流程输入数据
		/// </summary>

		public string InputData { get; set; }

		/// <summary>
		/// 流程表单定义HTML
		/// </summary>
		public string FormDefinition { get; set; }
		/// <summary>
		/// 业务类型
		/// </summary>
		public int? BusinessType { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public bool IsDeleted { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[System.Text.Json.Serialization.JsonIgnore]
		public MethodDto<WorkflowDefinition> MethodInput { get; set; }
	}
}
