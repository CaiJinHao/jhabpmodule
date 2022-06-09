using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;

namespace Jh.Abp.JhPermission
{
    public interface IJhPermissionAppService:  IApplicationService, IRemoteService
    {
        Task UpdateAsync(PermissionGrantedCreateInputDto inputDto);

        Task<IEnumerable<PermissionGrantedDto>> GetPermissionGrantedByNameAsync(PermissionGrantedByNameRetrieveInputDto input);

        /// <summary>
        /// 获取树
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ListResultDto<TreeAntdDto>> GetTreesAsync(PermissionTreesRetrieveInputDto inputDto);
    }
}
