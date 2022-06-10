using Jh.Abp.Common;
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

namespace Jh.Abp.JhPermission.JhPermission
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
            return CurrentUser.Roles.Any(a => (PermissionManager.GetAsync(permissionName, providerName, a).Result).IsGranted);
        }

        public virtual async Task UpdateAsync(PermissionGrantedCreateInputDto inputDto)
        {
            await CheckProviderPolicy(JhIdentityPermissions.JhPermissions.Update);
            var permissionsDefinition = PermissionDefinitionManager.GetPermissions();
            var permissions = permissionsDefinition
                               .Where(x => x.IsEnabled)
                               .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                               .Where(x => !x.Providers.Any() || x.Providers.Contains(inputDto.ProviderName))
                               .ToList();
            foreach (var item in permissions)
            {
                await PermissionManager.SetAsync(item.Name, inputDto.ProviderName, inputDto.RoleName, inputDto.PermissionNames.ToNullList().Contains(item.Name));
            }
        }

        /// <summary>
        /// 当前用户的权限，菜单及按钮权限
        /// </summary>
        /// <param name="input"></param>
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
            var permissions = permissionsDefinition
                                    .Where(x => x.IsEnabled)
                                    .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                                    .Where(x => !x.Providers.Any() || x.Providers.Contains(providerName))
                                    .ToList();
            return permissions;
        }

        public virtual async Task<ListResultDto<TreeAntdDto>> GetTreesAsync(PermissionTreesRetrieveInputDto inputDto)
        {
            await CheckProviderPolicy(inputDto.ProviderName);
            var permissions = GetPermissionGroups(inputDto.ProviderName);
            List<TreeAntdDto> GetChildrens(IEnumerable<PermissionDefinition> _pDefinitions)
            {
                var _p = new List<TreeAntdDto>();
                foreach (var item in _pDefinitions)
                {
                    //判断权限,必须要有父级权限
                    if (CheckPermission(item.Name, inputDto.ProviderName))
                    {
                        var node = new TreeAntdDto(item.Name, item.DisplayName.Localize(StringLocalizerFactory), item.Name);
                        if (item.Children.Count > 0)
                        {
                            node.children = GetChildrens(item.Children);
                        }
                        else
                        {
                            node.isLeaf = true;
                        }
                        _p.Add(node);
                    }
                }
                return _p;
            }

            var trees = GetChildrens(permissions);
            return new ListResultDto<TreeAntdDto>(trees);
        }
    }
}
