using Jh.Abp.Application;
using Jh.Abp.Domain;
using Jh.Abp.JhIdentity.Permissions.TenantManagement;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
    public class JhTenantAppService :
        CrudApplicationService<Tenant, TenantDto, TenantDto, System.Guid, TenantRetrieveInputDto, TenantCreateDto, TenantUpdateDto, TenantRetrieveInputDto>
        , IJhTenantAppService
    {

        public JhTenantAppService(ITenantRepository repository) : base(repository)
        {
        }

        public virtual async Task RecoverAsync(System.Guid id)
        {
            await CheckPolicyAsync(JhTenantManagementPermissions.Tenants.Recover);
            using (DataFilter.Disable<ISoftDelete>())
            {
                var entity = await crudRepository.FindAsync(id, false);
                entity.IsDeleted = false;
                entity.DeleterId = CurrentUser.Id;
                entity.DeletionTime = Clock.Now;
            }
        }
    }
}
