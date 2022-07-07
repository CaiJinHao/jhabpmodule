using Jh.Abp.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
    public class TenantRetrieveInputDto : PagedAndSortedResultRequestDto, IMethodDto<Tenant>
    {
        public string Name { get; set; }
        /// <summary>
        /// 方法参数回调
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public MethodDto<Tenant> MethodInput { get; set; }
    }
}
