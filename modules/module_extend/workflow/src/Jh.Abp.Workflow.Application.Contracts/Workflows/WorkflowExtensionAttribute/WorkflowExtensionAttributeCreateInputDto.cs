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
	/// 扩展属性
	/// </summary>
	public class WorkflowExtensionAttributeCreateInputDto: 
IMethodDto<WorkflowExtensionAttribute>
,IMultiTenant
	{
		/// <summary>
		/// ExecutionPointerId
		/// </summary>
		[Required]
		public Guid ExecutionPointerId { get; set; }
		/// <summary>
		/// AttributeKey
		/// </summary>
		public String AttributeKey { get; set; }
		/// <summary>
		/// AttributeValue
		/// </summary>
		public String AttributeValue { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowExtensionAttribute> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
