using Jh.Abp.Common;
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
            await CheckProviderPolicy(inputDto.ProviderName);

            var multiTenancySide = CurrentTenant.GetMultiTenancySide();
            var permissions = PermissionDefinitionManager.GetPermissions()
                .Where(a => (a.Providers.Contains(RolePermissionValueProvider.ProviderName) || a.Providers.Count == 0)
                && a.IsEnabled
                && a.MultiTenancySide.HasFlag(multiTenancySide));

            foreach (var item in permissions)
            {
                if (await SimpleStateCheckerManager.IsEnabledAsync(item))
                {
                    await PermissionManager.SetAsync(item.Name, inputDto.ProviderName, inputDto.ProviderKey, inputDto.PermissionNames.ToNullList().Contains(item.Name));
                }
            }
        }

        public virtual async Task<IEnumerable<PermissionGrantedDto>> GetPermissionGrantedByNameAsync(PermissionGrantedByNameRetrieveInputDto input)
        {
            await CheckProviderPolicy(input.ProviderName);
            var result = new List<PermissionGrantedDto>();
            foreach (var permissionName in input.PermissionNames)
            {
                var isGranted = CheckPermission(permissionName, input.ProviderName);
                result.Add(new PermissionGrantedDto() { Name = permissionName, Granted = isGranted });
            }
            return result;
        }

        public virtual Task<ListResultDto<TreeAntdDto>> GetTreesAsync(PermissionTreesRetrieveInputDto inputDto)
        {
            var permissionGroupDefinition = PermissionDefinitionManager.GetGroups();//根据模块名称分组的权限
            var permissionsDefinition = permissionGroupDefinition.SelectMany(a => a.Permissions);//根据表名分组的权限
            //当前用户角色有管理权限的表名权限集合
            var permissions = permissionsDefinition
                                    .Where(x => x.IsEnabled)
                                    .Where(x => x.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
                                    .Where(x => !x.Providers.Any() || x.Providers.Contains(inputDto.ProviderName))
                                    .ToList();

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
            return Task.FromResult(new ListResultDto<TreeAntdDto>(trees));
        }
    }
}
