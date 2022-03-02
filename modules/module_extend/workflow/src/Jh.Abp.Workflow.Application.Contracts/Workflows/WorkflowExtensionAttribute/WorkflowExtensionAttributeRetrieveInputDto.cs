using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 扩展属性
	/// </summary>
	public class WorkflowExtensionAttributeRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowExtensionAttribute>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowExtensionAttribute> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
