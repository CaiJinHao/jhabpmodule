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
	public class IdentityUserController : JhIdentityController, IIdentityUserAppService
    {
        public IProfileAppService ProfileAppService { get; set; }

        private readonly IIdentityUserAppService IdentityUserAppService;

        public IdentityUserController(IIdentityUserAppService identityUserAppService) 
        {
            IdentityUserAppService = identityUserAppService;
        }

        public IDataFilter<ISoftDelete> DataFilterDelete { get; set; }

        [Authorize(IdentityPermissions.Users.Create)]
        [HttpPost]
        public virtual async Task<IdentityUserDto> CreateAsync(IdentityUserCreateInputDto input)
        {
            return await IdentityUserAppService.CreateAsync(input);
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

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch]
        [Route("{id}/lockoutEnabled")]
        public virtual async Task UpdateLockoutEnabledAsync(Guid id, [FromBody] bool lockoutEnabled)
        {
            await IdentityUserAppService.UpdateLockoutEnabledAsync(id,lockoutEnabled);
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch]
        [HttpPut]
        [Route("{id}/Recover")]
        public async Task RecoverAsync(Guid id, [FromBody] bool isDelete)
        {
            await IdentityUserAppService.RecoverAsync(id, isDelete);
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
        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return await IdentityUserAppService.GetRolesAsync(id);
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet]
        public virtual async Task<PagedResultDto<IdentityUserDto>> GetListAsync([FromQuery] IdentityUserRetrieveInputDto input)
        {
            using (DataFilterDelete.Disable())
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
        [HttpGet("info")]
        public virtual async Task<IdentityUserDto> GetCurrentAsync()
        {
            return await IdentityUserAppService.GetCurrentAsync();
        }

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet]
        [Route("{id}/organizationunits")]
        public virtual async Task<ListResultDto<IdentityUserDto>> GetOrganizationsAsync(Guid id)
        {
            return await IdentityUserAppService.GetOrganizationsAsync(id);
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

        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet("/{userId}/SuperiorUser")]
        public async Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId)
        {
            return await IdentityUserAppService.GetSuperiorUserAsync(userId);
        }


        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        /// <returns></returns>
        [Authorize(IdentityPermissions.Users.Default)]
        [HttpGet("infoProfile")]
        public virtual Task<ProfileDto> GetProfileAsync()
        {
            return ProfileAppService.GetAsync();
        }

        //由于每个人都需要改密码所以注销权限
        //[Authorize(IdentityPermissions.Users.Update)]
        [Authorize]
        [HttpPost]
        [Route("change-password")]
        public virtual Task ChangePasswordAsync(ChangePasswordInput input)
        {
            return ProfileAppService.ChangePasswordAsync(input);
        }
    }
}
