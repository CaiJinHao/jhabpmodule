using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 执行错误
	/// </summary>
	public class WorkflowExecutionErrorCreateInputDto: 
IMethodDto<WorkflowExecutionError>
,IMultiTenant
	{
		/// <summary>
		/// 工作流ID
		/// </summary>
		[Required]
		public Guid WorkflowId { get; set; }
		/// <summary>
		/// 执行节点ID
		/// </summary>
		[Required]
		public Guid ExecutionPointerId { get; set; }
		/// <summary>
		/// 错误信息
		/// </summary>
		public String Message { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowExecutionError> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
