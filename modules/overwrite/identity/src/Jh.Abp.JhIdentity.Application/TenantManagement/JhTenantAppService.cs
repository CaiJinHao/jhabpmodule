using Jh.Abp.Application;
using Jh.Abp.Domain;
using System;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
    public class JhTenantAppService :
        CrudApplicationService<Tenant, TenantDto, TenantDto, System.Guid, TenantRetrieveInputDto, TenantCreateDto, TenantUpdateDto, TenantRetrieveInputDto>
        , IJhTenantAppService
    {
        public JhTenantAppService(ICrudRepository<Tenant, Guid> repository) : base(repository)
        {
        }
    }
}
