using Jh.Abp.Common.Utils;
using Jh.Abp.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using System.Linq;
using Jh.Abp.SettingManagement;

namespace Jh.Abp.JhIdentity.v1
{
    [DisableAuditing]
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class AppEnumsController
    {
        [Route("YesOrNo")]
        [HttpGet]
        public virtual Task<List<OptionDto<int>>> GetYesOrNoAsync()
        {
            var datas = UtilEnums.GetEnumListByDescription<YesOrNo>().ToList();
            return Task.FromResult(datas);
        }

        [Route("Provider")]
        [HttpGet]
        public virtual Task<List<OptionDto<int>>> GetSettingProviderAsync()
        {
            var datas = UtilEnums.GetEnumListByDescription<ProviderNameEnum>().ToList();
            return Task.FromResult(datas);
        }
    }
}
