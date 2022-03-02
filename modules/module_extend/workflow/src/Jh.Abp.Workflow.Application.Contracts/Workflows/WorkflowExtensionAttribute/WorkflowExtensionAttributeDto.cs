using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 扩展属性
	/// </summary>
	public class WorkflowExtensionAttributeDto: CreationAuditedEntityDto<System.Guid>
,IMultiTenant
	{
		/// <summary>
		/// ExecutionPointerId
		/// </summary>
		public Guid? ExecutionPointerId { get; set; }
		/// <summary>
		/// AttributeKey
		/// </summary>
		public String AttributeKey { get; set; }
		/// <summary>
		/// AttributeValue
		/// </summary>
		public String AttributeValue { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
