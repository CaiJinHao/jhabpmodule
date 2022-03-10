using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowScheduledCommandRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowScheduledCommand>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowScheduledCommand> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
