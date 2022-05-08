using Jh.Abp.Common.Utils;
using Jh.Abp.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;

namespace Jh.Abp.JhIdentity.v1
{
    [DisableAuditing]
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public partial class AppEnumsController
    {
        [Route("YesOrNo")]
        [HttpGet]
        public virtual Task<IEnumerable<OptionDto<int>>> GetYesOrNoAsync()
        {
            return Task.FromResult(UtilEnums.GetEnumListByDescription<YesOrNo>());
        }
    }
}
