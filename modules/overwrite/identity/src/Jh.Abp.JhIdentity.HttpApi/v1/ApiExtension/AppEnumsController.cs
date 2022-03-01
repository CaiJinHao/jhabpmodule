﻿using Jh.Abp.Domain.Shared;
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
    public class AppEnumsController
    {
        [Route("Use")]
        [HttpGet]
        public virtual Task<IEnumerable<dynamic>> GetUseAsync()
        {
            return Task.FromResult(Common.Utils.UtilEnums.GetEnumListByDescription<UseType>());
        }

        [Route("Delete")]
        [HttpGet]
        public virtual Task<IEnumerable<dynamic>> GetDeleteAsync()
        {
            return Task.FromResult(Common.Utils.UtilEnums.GetEnumListByDescription<DeleteType>());
        }
    }
}
