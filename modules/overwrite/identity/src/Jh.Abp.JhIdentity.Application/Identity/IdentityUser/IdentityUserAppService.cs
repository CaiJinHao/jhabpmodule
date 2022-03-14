using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;

namespace Jh.Abp.JhIdentity
{
    public class IdentityUserAppService
		: CrudApplicationService<IdentityUser, IdentityUserDto, IdentityUserDto, System.Guid, IdentityUserRetrieveInputDto, IdentityUserCreateInputDto, IdentityUserUpdateInputDto, IdentityUserDeleteInputDto>,
		IIdentityUserAppService
	{
        public IdentityUserManager UserManager { get; set; }
        protected IOrganizationUnitAppService OrganizationUnitAppService =>LazyServiceProvider.LazyGetRequiredService<OrganizationUnitAppService>();    
        protected IOrganizationUnitRepository organizationUnits => LazyServiceProvider.LazyGetRequiredService<IOrganizationUnitRepository>();
        protected Volo.Abp.Identity.IOrganizationUnitRepository organizationUnitRepository => LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IOrganizationUnitRepository>();
        protected IOptions<IdentityOptions> IdentityOptions { get; }

        private readonly IIdentityUserRepository IdentityUserRepository;
		private readonly IIdentityUserDapperRepository IdentityUserDapperRepository;
        public IdentityUserAppService(IIdentityUserRepository repository,
            IOptions<IdentityOptions> identityOptions, IIdentityUserDapperRepository identityuserDapperRepository) : base(repository)
        {
            IdentityUserRepository = repository;
            IdentityUserDapperRepository = identityuserDapperRepository;
            IdentityOptions = identityOptions;

            CreatePolicyName = IdentityPermissions.Users.Create;
            UpdatePolicyName = IdentityPermissions.Users.Update;
            DeletePolicyName = IdentityPermissions.Users.Delete;
            GetPolicyName = IdentityPermissions.Users.Default;
            GetListPolicyName = IdentityPermissions.Users.Default;
            BatchDeletePolicyName = IdentityPermissions.Users.Default;
        }

        public override async Task CreateAsync(IdentityUserCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await IdentityOptions.SetAsync();

            var user = new IdentityUser(
                GuidGenerator.Create(),
                inputDto.UserName,
                inputDto.Email,
                CurrentTenant.Id
            );

            if (inputDto.OrganizationUnitIds != null)
            {
                foreach (var item in inputDto.OrganizationUnitIds)
                {
                    user.AddOrganizationUnit(item);
                }
            }

            inputDto.MapExtraPropertiesTo(user);

            var methodDto = inputDto as IMethodDto<IdentityUser>;
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.CreateOrUpdateEntityAction != null)
                    {
                        methodDto.MethodInput.CreateOrUpdateEntityAction(user);
                    }
                }
            }

            (await UserManager.CreateAsync(user, inputDto.Password)).CheckErrors();
            await UpdateUserByInput(user, inputDto);
            (await UserManager.UpdateAsync(user)).CheckErrors();

            if (autoSave)
            {
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        protected virtual async Task UpdateUserByInput(IdentityUser user, IdentityUserCreateOrUpdateDto input, CancellationToken cancellationToken = default)
        {
            if (!string.Equals(user.Email, input.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                (await UserManager.SetEmailAsync(user, input.Email)).CheckErrors();
            }

            if (!string.Equals(user.PhoneNumber, input.PhoneNumber, StringComparison.InvariantCultureIgnoreCase))
            {
                (await UserManager.SetPhoneNumberAsync(user, input.PhoneNumber)).CheckErrors();
            }

            (await UserManager.SetLockoutEnabledAsync(user, input.LockoutEnabled)).CheckErrors();

            user.Name = input.Name;
            user.Surname = input.Surname;
            (await UserManager.UpdateAsync(user)).CheckErrors();

            if (input.RoleNames != null&& input.RoleNames.Any())
            {
                (await UserManager.SetRolesAsync(user, input.RoleNames)).CheckErrors();
            }
        }

        public override async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateInputDto input)
        {
            await IdentityOptions.SetAsync();

            var user = await UserManager.GetByIdAsync(id);
            user.ConcurrencyStamp = input.ConcurrencyStamp;

            (await UserManager.SetUserNameAsync(user, input.UserName)).CheckErrors();

            await UpdateUserByInput(user, input);
            input.MapExtraPropertiesTo(user);
            if (input.OrganizationUnitIds != null)
            {
                user.OrganizationUnits.Clear();
                foreach (var item in input.OrganizationUnitIds)
                {
                    user.AddOrganizationUnit(item);
                }
            }
            var methodDto = input as IMethodDto<IdentityUser>;
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.CreateOrUpdateEntityAction != null)
                    {
                        methodDto.MethodInput.CreateOrUpdateEntityAction(user);
                    }
                }
            }

            (await UserManager.UpdateAsync(user)).CheckErrors();

            if (!input.Password.IsNullOrEmpty())
            {
                (await UserManager.RemovePasswordAsync(user)).CheckErrors();
                (await UserManager.AddPasswordAsync(user, input.Password)).CheckErrors();
            }

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }

        public virtual async Task RecoverAsync(System.Guid id,bool isDelete)
        {
            await CheckUpdatePolicyAsync();
            using (DataFilter.Disable<ISoftDelete>())
            {
                var entity = await crudRepository.FindAsync(id, false);
                entity.IsDeleted = isDelete;
                entity.DeleterId = CurrentUser.Id;
                entity.DeletionTime = Clock.Now;
            }
        }

        public override async Task<IdentityUserDto> GetAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entity = await crudRepository.FindAsync(id, includeDetails, cancellationToken);
            var data = await MapToGetOutputDtoAsync(entity);
            await crudRepository.EnsureCollectionLoadedAsync(entity, u => u.OrganizationUnits, cancellationToken);
            data.OrganizationUnitIds = entity.OrganizationUnits.Select(a => a.OrganizationUnitId).ToArray();
            return data;
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            var roles = await IdentityUserRepository.GetRolesAsync(id);
            return new ListResultDto<IdentityRoleDto>(
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(roles)
            );
        }

        public override async Task<PagedResultDto<IdentityUserDto>> GetListAsync(IdentityUserRetrieveInputDto input, string methodStringType = "Contains", bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (input.OrganizationUnitId.HasValue)
            {
                var parentOrg = await organizationUnits.GetAsync(input.OrganizationUnitId.Value, includeDetails: false);
                input.MethodInput = new MethodDto<IdentityUser>()
                {
                    QueryAction = (entity) =>
                    {
                        var orgAllChildrens = organizationUnitRepository.GetAllChildrenWithParentCodeAsync(parentOrg.Code, parentOrg.Id).Result.Select(a => a.Id);
                        var userOrgs = organizationUnits.GetQueryableAsync<IdentityUserOrganizationUnit>().Result;
                        var query = from user in entity
                                    join userOrg in userOrgs on user.Id equals userOrg.UserId
                                    where userOrg.OrganizationUnitId == input.OrganizationUnitId || orgAllChildrens.Contains(userOrg.OrganizationUnitId)
                                    select user;
                        return (query).Distinct();
                    }
                };
            }
            return await base.GetListAsync(input, methodStringType, includeDetails, cancellationToken);
        }

        public virtual async Task<IdentityUserDto> GetCurrentAsync()
        {
            var user = await GetAsync((Guid)CurrentUser.Id);
            user.RoleIds = CurrentUser.FindClaims(JhJwtClaimTypes.RoleId).Select(a=>new Guid(a.Value)).ToArray();
            return user;
        }

        /// <summary>
        /// 获取部门领导
        /// </summary>
        public virtual async Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId)
        {
            var user= await IdentityUserRepository.GetSuperiorUserAsync(userId); 
            return await MapToGetOutputDtoAsync(user);
        }

        public virtual async Task<ListResultDto<IdentityUserDto>> GetOrganizationsAsync(Guid id)
        {
            var data = await OrganizationUnitAppService.GetMembersAsync(id);
            return new ListResultDto<IdentityUserDto>(data);
        }

        public virtual async Task UpdateLockoutEnabledAsync(Guid id, bool lockoutEnabled)
        {
            using (DataFilter.Disable<ISoftDelete>())
            {
                var user = await UserManager.GetByIdAsync(id);
                (await UserManager.SetLockoutEnabledAsync(user, lockoutEnabled)).CheckErrors();
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }
    }
}
