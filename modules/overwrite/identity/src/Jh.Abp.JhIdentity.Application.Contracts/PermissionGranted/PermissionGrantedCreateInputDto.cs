using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;

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
    }
}
