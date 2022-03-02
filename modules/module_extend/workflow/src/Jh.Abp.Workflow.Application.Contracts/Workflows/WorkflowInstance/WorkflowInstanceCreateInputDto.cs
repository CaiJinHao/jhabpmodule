using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 工作流实例
	/// </summary>
	public class WorkflowInstanceCreateInputDto: 
IMethodDto<WorkflowInstance>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		public String WorkflowDefinitionId { get; set; }
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		[Required]
		public Int32 Version { get; set; }
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
		[Required]
		public WorkflowStatus Status { get; set; }
		/// <summary>
		/// 业务类型
		/// </summary>
		public int? BusinessType { get; set; }
		/// <summary>
		/// 业务数据ID
		/// </summary>
		public string BusinessDataId { get; set; }

		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowInstance> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}