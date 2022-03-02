using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 工作流定义
	/// </summary>
	public class WorkflowDefinitionDto: ExtensibleFullAuditedEntityDto<System.Guid>
,IHasConcurrencyStamp
,IMultiTenant
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
		/// 并发标识
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
