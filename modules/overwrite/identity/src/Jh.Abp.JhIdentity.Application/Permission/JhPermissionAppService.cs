using Jh.Abp.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SimpleStateChecking;

namespace Jh.Abp.JhPermission.JhPermission
{
    [DisableAuditing]
    public class JhPermissionAppService : PermissionAppService, IJhPermissionAppService, ITransientDependency
    {
        public JhPermissionAppService(IPermissionManager permissionManager, IPermissionDefinitionManager permissionDefinitionManager, IOptions<PermissionManagementOptions> options, ISimpleStateCheckerManager<PermissionDefinition> simpleStateCheckerManager) : base(permissionManager, permissionDefinitionManager, options, simpleStateCheckerManager)
        {
        }

        public virtual async Task<IEnumerable<TreeDto>> GetPermissionTreesAsync(string providerName, string providerKey)
        {
            await CheckProviderPolicy(providerName);
            var datas = await GetPermissionGrantsAsync();
            var results = new List<TreeDto>();
            foreach (var permission in datas)
            {
                var isGranted = await GetCurentUserByPermissionName(permission.Name + ".ManagePermissions", providerName);
                if (!isGranted)
                {
                    //判断当前登录用户的角色是否可以编辑当前菜单的权限，不能编辑就不显示了
                    continue;
                }
                var parentPermission = await PermissionManager.GetAsync(permission.Name, providerName, providerKey);//获取当前权限组的选中信息
                var module = permission.DisplayName.Localize(StringLocalizerFactory);//本地化当前权限的名称
                var modulePermission = new TreeDto()
                {
                    id = permission.Name,
                    title = module.Value,
                    value = permission.Name,
                    sort = permission.Name,
                    @checked = parentPermission.IsGranted,
                    disabled = false,
                };
                var childs = new List<TreeDto>() { modulePermission };
                {//childs
                    foreach (var item in permission.Children)//拿到当前权限组的子列表
                    {
                        var itemPermission = await PermissionManager.GetAsync(item.Name, providerName, providerKey);
                        var a = item.DisplayName.Localize(StringLocalizerFactory);
                        childs.Add(new TreeDto()
                        {
                            id = item.Name,
                            parent_id = permission.Name,
                            title = a.Value,
                            value = item.Name,
                            @checked = itemPermission.IsGranted,
                            sort = item.Name,
                            disabled = false
                        });
                    }
                }
                results.Add(new TreeDto()
                {
                    id = $"yezi{permission.Name}",
                    title = module.Value,
                    value = $"yezi{permission.Name}",
                    sort = permission.Name,
                    @checked = parentPermission.IsGranted,
                    disabled = false,
                    children = childs
                });
            }
            return results;
        }

        protected virtual Task<IEnumerable<PermissionDefinition>> GetPermissionGrantsAsync()
        {
            var multiTenancySide = CurrentTenant.GetMultiTenancySide();
            var datas = PermissionDefinitionManager.GetGroups()
                .SelectMany(g => g.Permissions)
                .Where(a => (a.Providers.Contains(RolePermissionValueProvider.ProviderName) || a.Providers.Count == 0)
                && a.IsEnabled
                && a.MultiTenancySide.HasFlag(multiTenancySide));
            return Task.FromResult(datas);
        }

        public virtual async Task UpdateAsync(string providerName, string providerKey, string[] permissionNames)
        {
            await CheckProviderPolicy(providerName);

            var multiTenancySide = CurrentTenant.GetMultiTenancySide();
            var permissions = PermissionDefinitionManager.GetPermissions()
                .Where(a => (a.Providers.Contains(RolePermissionValueProvider.ProviderName) || a.Providers.Count == 0)
                && a.IsEnabled
                && a.MultiTenancySide.HasFlag(multiTenancySide));

            foreach (var item in permissions)
            {
                if (await SimpleStateCheckerManager.IsEnabledAsync(item))
                {
                    await PermissionManager.SetAsync(item.Name, providerName, providerKey, permissionNames.ToNullList().Contains(item.Name));
                }
            }
        }

        public virtual async Task<dynamic> GetMenuSelectPermissionGrantsAsync()
        {
            var result = new List<dynamic>();
            var datas = await GetPermissionGrantsAsync();
            foreach (var item in datas)
            {
                var module = item.DisplayName.Localize(StringLocalizerFactory);
                result.Add(new { name = module.Value, value = item.Name });
            }
            return result;
        }

        public virtual async Task<IEnumerable<PermissionGrantedDto>> GetPermissionGrantedByNameAsync(PermissionGrantedRetrieveInputDto input)
        {
            await CheckProviderPolicy(input.ProviderName);
            var result = new List<PermissionGrantedDto>();
            foreach (var permissionName in input.PermissionNames)
            {
                var isGranted = await GetCurentUserByPermissionName(permissionName, input.ProviderName);
                result.Add(new PermissionGrantedDto() { Name = permissionName, Granted = isGranted });
            }
            return result;
        }

        /// <summary>
        /// 只要当前用户有一个角色有权限就返回true
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        protected async Task<bool> GetCurentUserByPermissionName(string permissionName, string providerName)
        {
            var isGranted = false;
            foreach (var providerKey in CurrentUser.Roles)
            {
                try
                {
                    var managePermission = await PermissionManager.GetAsync(permissionName, providerName, providerKey);
                    isGranted = managePermission.IsGranted;
                    if (isGranted)
                    {
                        break;
                    }
                }
                catch (Exception)
                {

                }
            }
            return isGranted;
        }
    }
}
