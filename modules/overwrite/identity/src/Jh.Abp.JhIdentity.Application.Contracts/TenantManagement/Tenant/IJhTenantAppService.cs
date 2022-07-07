using Jh.Abp.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
    public interface IJhTenantAppService
        : ICrudApplicationService<Tenant, TenantDto, TenantDto, System.Guid, TenantRetrieveInputDto, TenantCreateDto, TenantUpdateDto, TenantRetrieveInputDto>
    {
    }
}
