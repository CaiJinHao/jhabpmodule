using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Extensions;
using Jh.Abp.Common.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
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
        public IProfileAppService ProfileAppService { get; set; }
        public IdentityUserManager UserManager { get; set; }
        protected IOrganizationUnitAppService OrganizationUnitAppService =>LazyServiceProvider.LazyGetRequiredService<OrganizationUnitAppService>();    
        protected IOrganizationUnitRepository OrganizationUnits => LazyServiceProvider.LazyGetRequiredService<IOrganizationUnitRepository>();
        protected Volo.Abp.Identity.IOrganizationUnitRepository OrganizationUnitRepository => LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IOrganizationUnitRepository>();
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

        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateInputDto inputDto)
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

            if (inputDto is IMethodDto<IdentityUser> methodDto)
            {
                if (methodDto.MethodInput != null)
                {
                    methodDto.MethodInput.CreateOrUpdateEntityAction?.Invoke(user);
                }
            }
            //await UserManager.SetLockoutEnabledAsync(user, true);//启用登录错误锁
            (await UserManager.CreateAsync(user, inputDto.Password)).CheckErrors();
            await UpdateUserByInput(user, inputDto);
            (await UserManager.UpdateAsync(user)).CheckErrors();

            await CurrentUnitOfWork.SaveChangesAsync();
            return MapToGetOutputDto(user);
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

        public virtual async Task ChangePasswordAsync(ChangePasswordInputDto input)
        {
            await ProfileAppService.ChangePasswordAsync(new ChangePasswordInput() { CurrentPassword = input.CurrentPassword, NewPassword = input.NewPassword });
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
            if (input is IMethodDto<IdentityUser> methodDto)
            {
                if (methodDto.MethodInput != null)
                {
                    methodDto.MethodInput.CreateOrUpdateEntityAction?.Invoke(user);
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

        public virtual async Task RecoverAsync(System.Guid id)
        {
            await CheckPolicyAsync(JhIdentityPermissions.IdentityUsers.Recover);
            using (DataFilter.Disable<ISoftDelete>())
            {
                var entity = await crudRepository.FindAsync(id, false);
                entity.IsDeleted = false;
                entity.DeleterId = CurrentUser.Id;
                entity.DeletionTime = Clock.Now;
            }
        }

        public override async Task<IdentityUserDto> GetAsync(Guid id)
        {
            var entity = await crudRepository.FindAsync(id);
            var data = await MapToGetOutputDtoAsync(entity);
            await crudRepository.EnsureCollectionLoadedAsync(entity, u => u.OrganizationUnits);
            data.OrganizationUnitIds = entity.OrganizationUnits.Select(a => a.OrganizationUnitId).ToArray();
            await crudRepository.EnsureCollectionLoadedAsync(entity, u => u.Roles);
            data.RoleIds = entity.Roles.Select(a => a.RoleId).ToArray();
            return data;
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            var roles = await IdentityUserRepository.GetRolesAsync(id);
            return new ListResultDto<IdentityRoleDto>(
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(roles)
            );
        }

        public override async Task<PagedResultDto<IdentityUserDto>> GetListAsync(IdentityUserRetrieveInputDto input)
        {
            if (input.OrganizationUnitId.HasValue)
            {
                var parentOrg = await OrganizationUnits.GetAsync(input.OrganizationUnitId.Value, includeDetails: false);
                input.MethodInput = new MethodDto<IdentityUser>()
                {
                    QueryAction = (entity) =>
                    {
                        var orgAllChildrens = OrganizationUnitRepository.GetAllChildrenWithParentCodeAsync(parentOrg.Code, parentOrg.Id).Result.Select(a => a.Id);
                        var userOrgs = OrganizationUnits.GetQueryableAsync<IdentityUserOrganizationUnit>().Result;
                        var query = from user in entity
                                    join userOrg in userOrgs on user.Id equals userOrg.UserId
                                    where (userOrg.OrganizationUnitId == input.OrganizationUnitId || orgAllChildrens.Contains(userOrg.OrganizationUnitId))
                                    && user.UserName != JhIdentity.JhIdentityConsts.AdminUserName
                                    select user;
                        return (query).Distinct();
                    }
                };
            }
            else
            {
                input.MethodInput = new MethodDto<IdentityUser>()
                {
                    QueryAction = (entity) =>
                    {
                        return entity.Where(a=>a.UserName != JhIdentity.JhIdentityConsts.AdminUserName);
                    }
                };
            }
            return await base.GetListAsync(input);
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
            return await OrganizationUnitAppService.GetMembersAsync(id);
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

        public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync()
        {
            var query = await IdentityUserRepository.GetQueryableAsync(true);
            return new ListResultDto<OptionDto<Guid>>(query.Where(a => a.UserName != JhIdentitySettings.SuperadminUserName)
                .Select(a => new OptionDto<Guid> { Label = $"{a.Name}-{a.UserName}", Value = a.Id }).ToList());
        }
    }
}
