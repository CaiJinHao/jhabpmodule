using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationUnitCreateInputDto:
ExtensibleObject, IHasConcurrencyStamp,
IMethodDto<OrganizationUnit>
	{
		public new ExtraPropertyDictionary ExtraProperties { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Guid? ParentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String DisplayName { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<OrganizationUnit> MethodInput { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }

		public Guid[] RoleIds { get; set; }
	}
}
