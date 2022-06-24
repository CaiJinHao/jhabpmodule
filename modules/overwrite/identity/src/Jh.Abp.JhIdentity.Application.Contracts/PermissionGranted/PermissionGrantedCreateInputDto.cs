using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using System.Linq;
using Jh.Abp.JhIdentity;

namespace Jh.Abp.JhPermission
{
    public  class PermissionGrantedCreateInputDto
    {
        /// <summary>
        /// 权限名称列表
        /// </summary>
        public string[] PermissionNames { get; set; }
        public string ProviderName { get; set; } = RolePermissionValueProvider.ProviderName;
        public string RoleName { get; set; }

        public bool AnyPermissionName(string permissionName)
        {
            if (PermissionNames==null)
            {
                return false;
            }
            return PermissionNames.Any(a => a == permissionName);
            /*if (PermissionNames != null)
            {
                return PermissionNames.Where(a => !a.Contains(JhIdentityConsts.PermissionGroupPrefix)).ToList();//不包含分组的前缀
            }
            return new List<string>();*/
        }
    }
}
