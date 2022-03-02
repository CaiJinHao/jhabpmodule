using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 工作流实例
	/// </summary>
	public class WorkflowInstanceDto: CreationAuditedEntityDto<System.Guid>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		public String WorkflowDefinitionId { get; set; }
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		public Int32? Version { get; set; }
		/// <summary>
		/// Description
		/// </summary>
		public String Description { get; set; }
		/// <summary>
		/// Reference
		/// </summary>
		public String Reference { get; set; }
		/// <summary>
		/// NextExecution
		/// </summary>
		public Int64? NextExecution { get; set; }
		/// <summary>
		/// Data
		/// </summary>
		public String Data { get; set; }
		/// <summary>
		/// CompleteTime
		/// </summary>
		public DateTime? CompleteTime { get; set; }
		/// <summary>
		/// Status
		/// </summary>
		public WorkflowStatus? Status { get; set; }
		/// <summary>
		/// 业务类型
		/// </summary>
		public int? BusinessType { get; set; }
		/// <summary>
		/// 业务数据ID
		/// </summary>
		public string BusinessDataId { get; set; }
		public virtual Guid? TenantId { get; set; }
	}
}
