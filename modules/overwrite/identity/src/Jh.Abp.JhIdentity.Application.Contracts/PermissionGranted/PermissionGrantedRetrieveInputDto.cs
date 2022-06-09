﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.JhPermission
{

    public class PermissionGrantedRetrieveInputDto
    {
        public string ProviderName { get; set; } = RolePermissionValueProvider.ProviderName;
        public string RoleName { get; set; }
    }
    public class PermissionTreesRetrieveInputDto
    {
        public string ProviderName { get; set; } = RolePermissionValueProvider.ProviderName;
    }

    public class PermissionGrantedByNameRetrieveInputDto
    {
        public string[] PermissionNames { get; set; }
        public string ProviderName { get; set; } = RolePermissionValueProvider.ProviderName;
    }

    
}
