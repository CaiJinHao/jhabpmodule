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

        Task<ListResultDto<TreeDto>> GetPermissionTreesAsync(PermissionTreesRetrieveInputDto inputDto);
    }
}
