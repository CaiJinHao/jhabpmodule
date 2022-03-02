using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 执行错误
	/// </summary>
	public class WorkflowExecutionErrorUpdateInputDto: 
IMethodDto<WorkflowExecutionError>
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
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowExecutionError> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
