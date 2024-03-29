﻿using Jh.Abp.Common;
using Jh.Abp.JhIdentity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SimpleStateChecking;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.PermissionManagement
{
    [DisableAuditing]
    public class JhPermissionAppService : PermissionAppService, IJhPermissionAppService, IPermissionAppService, ITransientDependency
    {
        public JhPermissionAppService(IPermissionManager permissionManager, IPermissionDefinitionManager permissionDefinitionManager, IOptions<PermissionManagementOptions> options, ISimpleStateCheckerManager<PermissionDefinition> simpleStateCheckerManager) : base(permissionManager, permissionDefinitionManager, options, simpleStateCheckerManager)
        {
        }

        /// <summary>
        /// 只要当前用户有一个角色有权限就返回true
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        protected bool CheckPermission(string permissionName, string providerName)
        {
            return CurrentUser.Roles.Any(a => PermissionManager.GetAsync(permissionName, providerName, a).Result.IsGranted);
        }

        protected bool CheckManagerPermission(IEnumerable<PermissionDefinition> permissionDefinitions,string providerName) {
            var permissionManager = permissionDefinitions.FirstOrDefault(a => a.Name.Contains(".ManagePermissions"));
            if (permissionManager != null)
            {
                return CurrentUser.Roles.Any(a => PermissionManager.GetAsync(permissionManager.Name, providerName, a).Result.IsGranted);
            }
            return true;
        }

        public virtual async Task UpdateAsync(PermissionGrantedCreateInputDto inputDto)
        {
            await CheckPolicyAsync(JhIdentityPermissions.JhPermissions.Update);
            var permissionsDefinition = PermissionDefinitionManager.GetPermissions();
            var permissions = permissionsDefinition
                               .Where(x => x.IsEnabled)
                               .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                               .Where(x => !x.Providers.Any() || x.Providers.Contains(inputDto.ProviderName))
                               .ToList();
            foreach (var item in permissions)
            {
                await PermissionManager.SetAsync(item.Name, inputDto.ProviderName, inputDto.RoleName, inputDto.AnyPermissionName(item.Name));
            }
        }

        /// <summary>
        /// 当前用户的权限，菜单及按钮权限
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ListResultDto<PermissionGrantedDto>> GetCurrentGrantedAsync()
        {
            var allPermission = new List<PermissionWithGrantedProviders>();
            foreach (var roleName in CurrentUser.Roles)
            {
                var grantedPermission = await PermissionManager.GetAllAsync(RolePermissionValueProvider.ProviderName, roleName);
                allPermission.AddRange(grantedPermission);
            }
            var datas = allPermission.Distinct().Select(a => new PermissionGrantedDto() { Name = a.Name, IsGranted = a.IsGranted }).ToList();
            return new ListResultDto<PermissionGrantedDto>(datas);
        }

        public virtual async Task<ListResultDto<string>> GetPermissionGrantedByRoleAsync(PermissionGrantedRetrieveInputDto input)
        {
            var grantedPermission = await PermissionManager.GetAllAsync(input.ProviderName, input.RoleName);
            var datas = grantedPermission.Where(a=>a.IsGranted).Select(a => a.Name).ToList();
            return new ListResultDto<string>(datas);
        }

        protected virtual List<PermissionDefinition> GetPermissionGroups(string providerName)
        {
            var permissionGroupDefinition = PermissionDefinitionManager.GetGroups();//根据模块名称分组的权限
            var permissionsDefinition = permissionGroupDefinition.SelectMany(a => a.Permissions);//根据表名分组的权限
            //当前用户角色有管理权限的表名权限集合
            return permissionsDefinition
                                    .Where(x => x.IsEnabled)
                                    .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                                    .Where(x => !x.Providers.Any() || x.Providers.Contains(providerName))
                                    .ToList();
        }

        public virtual async Task<ListResultDto<TreeAntdDto>> GetTreesAsync(PermissionTreesRetrieveInputDto inputDto)
        {
            await CheckPolicyAsync(JhIdentityPermissions.JhPermissions.Default);
            var permissions = PermissionDefinitionManager.GetGroups();
            if (!(CurrentUser.Roles.Any(a => a == JhIdentityConsts.AdminRoleName) && !CurrentUser.TenantId.HasValue))
            {
                //不存在任何租户，并且是admin
                permissions = permissions.Where(a => a.Name != TenantManagementPermissions.GroupName).ToList();
            }

            List <TreeAntdDto> GetChildrens(IReadOnlyList<PermissionDefinition> _pDefinitions)
            {
                var _p = new List<TreeAntdDto>();
                var pdefs= _pDefinitions.Where(x => x.IsEnabled)
                                    .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                                    .Where(x => !x.Providers.Any() || x.Providers.Contains(inputDto.ProviderName));
                foreach (var item in pdefs)
                {
                    if (CheckPermission(item.Name, inputDto.ProviderName)&& CheckManagerPermission(pdefs, inputDto.ProviderName))
                    {
                        var node = new TreeAntdDto(item.Name, item.DisplayName.Localize(StringLocalizerFactory), item.Name);
                        if (item.Children.Count > 0)
                        {
                            var children = GetChildrens(item.Children);
                            if (children.Any())
                            {
                                node.id = $"{JhIdentityConsts.PermissionGroupPrefix}{item.Name}";
                                node.children = new List<TreeAntdDto>() { new TreeAntdDto(item.Name, node.title, item.Name) { isLeaf = true } };
                                node.children.AddRange(children);
                                _p.Add(node);
                            }
                        }
                        else
                        {
                            node.isLeaf = true;
                            _p.Add(node);
                        }
                    }
                }
                return _p;
            }
            var trees = new List<TreeAntdDto>();
            //租户管理只有全局admin可以查看，不能分配权限
            foreach (var item in permissions.Where(a =>
                            a.Permissions.Where(x => x.IsEnabled)
                            .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                            .Where(x => !x.Providers.Any() || x.Providers.Contains(inputDto.ProviderName)).Any()
                        ))
            {
                var node = new TreeAntdDto(item.Name, item.DisplayName.Localize(StringLocalizerFactory), item.Name);//保存的时候需要过滤掉
                node.children = GetChildrens(item.Permissions);
                if (node.children != null && node.children.Any())
                {
                    trees.Add(node);
                }
            }
            return new ListResultDto<TreeAntdDto>(trees);
        }
    }
}
