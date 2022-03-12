using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;

namespace Jh.Abp.JhPermission
{
    public interface IJhPermissionAppService: IPermissionAppService, IApplicationService, IRemoteService
    {
        Task UpdateAsync(string providerName, string providerKey, string[] PermissionNames);

        Task<dynamic> GetMenuSelectPermissionGrantsAsync();

        Task<IEnumerable<PermissionGrantedDto>> GetPermissionGrantedByNameAsync(PermissionGrantedRetrieveInputDto input);

        Task<IEnumerable<TreeDto>> GetPermissionTreesAsync(string providerName, string providerKey);
    }
}
