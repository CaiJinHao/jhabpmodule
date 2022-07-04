using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;

namespace Jh.Abp.PermissionManagement
{
    public interface IJhPermissionAppService:  IApplicationService, IRemoteService
    {
        Task UpdateAsync(PermissionGrantedCreateInputDto inputDto);

        /// <summary>
        /// 获取树
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        [DisableAuditing]
        Task<ListResultDto<TreeAntdDto>> GetTreesAsync(PermissionTreesRetrieveInputDto inputDto);

        [DisableAuditing]
        Task<ListResultDto<string>> GetPermissionGrantedByRoleAsync(PermissionGrantedRetrieveInputDto input);

        /// <summary>
        /// 获取当前用户的授权权限列表，用于前端渲染
        /// </summary>
        /// <returns></returns>
        [DisableAuditing]
        Task<ListResultDto<PermissionGrantedDto>> GetCurrentGrantedAsync();
    }
}
