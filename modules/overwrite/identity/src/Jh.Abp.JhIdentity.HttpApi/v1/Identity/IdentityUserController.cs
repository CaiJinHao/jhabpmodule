using Jh.Abp.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Jh.Abp.JhIdentity.v1
{
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class IdentityUserController : JhIdentityController, IIdentityUserRemoteService
    {
        public IdentityUserManager UserManager { get; set; }
        public IOrganizationUnitAppService organizationUnitAppService { get; set; }
        public IProfileAppService ProfileAppService { get; set; }
        public IPermissionDefinitionManager PermissionDefinitionManager { get; set; }

        private readonly IIdentityUserAppService IdentityUserAppService;

        public IdentityUserController(IIdentityUserAppService identityUserAppService) 
        {
            IdentityUserAppService = identityUserAppService;
        }

        public IDataFilter<ISoftDelete> dataFilter { get; set; }

        [Authorize(IdentityPermissions.Users.Create)]
        [HttpPost]
        public virtual async Task CreateAsync(IdentityUserCreateInputDto input)
        {
            await IdentityUserAppService.CreateAsync(input, true);
        }

        [Authorize(IdentityPermissions.Users.Delete)]
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(System.Guid id)
        {
            await IdentityUserAppService.DeleteAsync(id);
        }

        [Authorize(IdentityPermissions.Users.Delete)]
        [Route("keys")]
        [HttpDelete]
        public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
        {
            await IdentityUserAppService.DeleteAsync(keys);
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPut("{id}")]
        public virtual async Task<IdentityUserDto> UpdateAsync(System.Guid id, IdentityUserUpdateInputDto input)
        {
            return await IdentityUserAppService.UpdateAsync(id, input);
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch("{id}")]
        public virtual async Task UpdatePortionAsync(System.Guid id, IdentityUserUpdateInputDto inputDto)
        {
            await IdentityUserAppService.UpdatePortionAsync(id, inputDto);
        }

        //由于每个人都需要改密码所以注销权限
        //[Authorize(IdentityPermissions.Users.Update)]
        [HttpPost]
        [Route("change-password")]
        public virtual Task ChangePasswordAsync(ChangePasswordInput input)
        {
            return ProfileAppService.ChangePasswordAsync(input);
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch]
        [Route("{id}/lockoutEnabled")]
        public virtual async Task UpdateLockoutEnabledAsync(Guid id, [FromBody] bool lockoutEnabled)
        {
            using (dataFilter.Disable())
            {
                var user = await UserManager.GetByIdAsync(id);
                (await UserManager.SetLockoutEnabledAsync(user, lockoutEnabled)).CheckErrors();
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch]
        [HttpPut]
        [Route("{id}/Recover")]
        public async Task RecoverAsync(Guid id, [FromBody] bool isDelete)
        {
            await IdentityUserAppService.RecoverAsync(id, isDelete);
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch]
        [Route("{id}/Deleted")]
        public virtual async Task UpdateDeletedAsync(Guid id, [FromBody] bool isDeleted)
        {
            using (dataFilter.Disable())
            {
                var user = await UserManager.GetByIdAsync(id);
                user.IsDeleted = isDeleted;
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet("{id}")]
        public virtual async Task<IdentityUserDto> GetAsync(System.Guid id)
        {
           return await IdentityUserAppService.GetAsync(id);
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet]
        [Route("{id}/roles")]
        public virtual async Task<dynamic> GetRolesAsync(Guid id)
        {
            var datas = await IdentityUserAppService.GetRolesAsync(id);
            return new
            {
                items = datas.Items.Select(a => new { name = a.Name, value = a.Id })
            };
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet]
        public virtual async Task<PagedResultDto<IdentityUserDto>> GetListAsync([FromQuery] IdentityUserRetrieveInputDto input)
        {
            using (dataFilter.Disable())
            {
                return await IdentityUserAppService.GetListAsync(input);
            }
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [Route("all")]
        [HttpGet]
        public virtual async Task<ListResultDto<IdentityUserDto>> GetEntitysAsync([FromQuery] IdentityUserRetrieveInputDto inputDto)
        {
            return await IdentityUserAppService.GetEntitysAsync(inputDto);
        }

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        /// <returns></returns>
        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet("infoProfile")]
        public virtual Task<ProfileDto> GetLoginInfoV1Async()
        {
            return ProfileAppService.GetAsync();
        }

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        /// <returns></returns>
        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet("info")]
        public virtual async Task<IdentityUserDto> GetLoginInfoAsync()
        {
            return await IdentityUserAppService.GetCurrentAsync();
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet("{id}/Permissions")]
        public virtual IEnumerable<string> GePermissionsAsync()
        {
            var datas = PermissionDefinitionManager.GetPermissions();
            return datas.Select(a => a.Name).ToList();
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet]
        [Route("{id}/organizationunits")]
        public virtual async Task<dynamic> GetOrganizationsAsync(Guid id)
        {
            var datas = await organizationUnitAppService.GetMembersAsync(id);
            return new
            {
                items = datas.Select(a => new { name = a.Name, value = a.Id })
            };
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [Route("options")]
        [HttpGet]
        public virtual async Task<ListResultDto<IdentityUserDto>> GetOptionsAsync([FromQuery] IdentityUserRetrieveInputDto inputDto)
        {
            inputDto.MethodInput = new MethodDto<IdentityUser>()
            {
                SelectAction = (query) => query.Where(a => a.UserName != JhIdentitySettings.SuperadminUserName).Select(a => new IdentityUser(a.Id, a.UserName, a.Email, null) { Name = a.Name })
            };
            return await IdentityUserAppService.GetEntitysAsync(inputDto);
        }
    }
}
