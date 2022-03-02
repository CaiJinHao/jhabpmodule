using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
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
