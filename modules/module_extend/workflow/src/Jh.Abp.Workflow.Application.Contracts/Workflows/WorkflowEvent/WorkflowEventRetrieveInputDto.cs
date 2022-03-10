using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 事件
    /// </summary>
    public class WorkflowEventRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowEvent>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowEvent> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
