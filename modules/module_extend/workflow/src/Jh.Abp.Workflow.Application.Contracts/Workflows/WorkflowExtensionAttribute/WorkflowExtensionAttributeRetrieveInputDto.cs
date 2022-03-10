using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

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
