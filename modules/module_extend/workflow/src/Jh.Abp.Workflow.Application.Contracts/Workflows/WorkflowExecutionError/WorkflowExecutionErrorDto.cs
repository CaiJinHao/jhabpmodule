using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 执行错误
	/// </summary>
	public class WorkflowExecutionErrorDto: CreationAuditedEntityDto<System.Guid>
,IMultiTenant
	{
		/// <summary>
		/// 工作流ID
		/// </summary>
		public Guid? WorkflowId { get; set; }
		/// <summary>
		/// 执行节点ID
		/// </summary>
		public Guid? ExecutionPointerId { get; set; }
		/// <summary>
		/// 错误信息
		/// </summary>
		public String Message { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
