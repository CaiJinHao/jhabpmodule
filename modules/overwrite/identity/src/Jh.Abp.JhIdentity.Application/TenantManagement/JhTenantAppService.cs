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

        //public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync()
        //{
        //    var query = await IdentityUserRepository.GetQueryableAsync(true);
        //    return new ListResultDto<OptionDto<Guid>>(query.Where(a => a.UserName != JhIdentitySettings.SuperadminUserName)
        //        .Select(a => new OptionDto<Guid> { Label = $"{a.Name}-{a.UserName}", Value = a.Id }).ToList());
        //}
    }
}
