using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<Menu>
, IRetrieveDelete
,IMultiTenant
	{
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Deleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<Menu> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }

		/// <summary>
		/// 菜单编号
		/// </summary>
		public string MenuCode { get; set; }

		/// <summary>
		/// 菜单名称
		/// </summary>
		public string MenuName { get; set; }

		public int? Sort { get; set; }

		/// <summary>
		/// 上级菜单编号，顶级可为null
		/// </summary>
		public string MenuParentCode { get; set; }
		public string OrMenuCode { get; set; }
	}
}
