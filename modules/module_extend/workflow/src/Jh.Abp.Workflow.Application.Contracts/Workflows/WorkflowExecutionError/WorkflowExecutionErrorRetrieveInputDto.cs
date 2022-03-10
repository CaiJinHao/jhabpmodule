using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 执行错误
    /// </summary>
    public class WorkflowExecutionErrorRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowExecutionError>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowExecutionError> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
