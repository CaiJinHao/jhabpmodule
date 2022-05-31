using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
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
        private readonly IIdentityUserAppService IdentityUserAppService;

        public IdentityUserController(IIdentityUserAppService identityUserAppService) 
        {
            IdentityUserAppService = identityUserAppService;
        }

        public IDataFilter<ISoftDelete> DataFilterDelete { get; set; }

        [Authorize(JhIdentityPermissions.IdentityUsers.Create)]
        [HttpPost]
        public virtual async Task<IdentityUserDto> CreateAsync(IdentityUserCreateInputDto input)
        {
            return await IdentityUserAppService.CreateAsync(input);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Delete)]
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(System.Guid id)
        {
            await IdentityUserAppService.DeleteAsync(id);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Delete)]
        [Route("keys")]
        [HttpDelete]
        public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
        {
            await IdentityUserAppService.DeleteAsync(keys);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Update)]
        [HttpPut("{id}")]
        public virtual async Task<IdentityUserDto> UpdateAsync(System.Guid id, IdentityUserUpdateInputDto input)
        {
            return await IdentityUserAppService.UpdateAsync(id, input);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Update)]
        //[HttpPut("Patch/{id}")]//兼容手机端，手机端不支持Patch
        [HttpPatch("{id}")]
        public virtual async Task UpdatePortionAsync(System.Guid id, IdentityUserUpdateInputDto inputDto)
        {
            await IdentityUserAppService.UpdatePortionAsync(id, inputDto);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Update)]
        [HttpPatch]
        [Route("{id}/lockoutEnabled")]
        public virtual async Task UpdateLockoutEnabledAsync(Guid id, [FromBody] bool lockoutEnabled)
        {
            await IdentityUserAppService.UpdateLockoutEnabledAsync(id,lockoutEnabled);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Recover)]
        [HttpPatch]
        //[HttpPut]
        [Route("{id}/Recover")]
        public async Task RecoverAsync(Guid id)
        {
            await IdentityUserAppService.RecoverAsync(id);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [HttpGet("{id}")]
        public virtual async Task<IdentityUserDto> GetAsync(System.Guid id)
        {
           return await IdentityUserAppService.GetAsync(id);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [HttpGet]
        [Route("{id}/roles")]
        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return await IdentityUserAppService.GetRolesAsync(id);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [HttpGet]
        public virtual async Task<PagedResultDto<IdentityUserDto>> GetListAsync([FromQuery] IdentityUserRetrieveInputDto input)
        {
            using (DataFilterDelete.Disable())
            {
                return await IdentityUserAppService.GetListAsync(input);
            }
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
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
        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [HttpGet("info")]
        public virtual async Task<IdentityUserDto> GetCurrentAsync()
        {
            return await IdentityUserAppService.GetCurrentAsync();
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [HttpGet]
        [Route("{id}/organizationunits")]
        public virtual async Task<ListResultDto<IdentityUserDto>> GetOrganizationsAsync(Guid id)
        {
            return await IdentityUserAppService.GetOrganizationsAsync(id);
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [Route("options")]
        [HttpGet]
        public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync()
        {
            return await IdentityUserAppService.GetOptionsAsync();
        }

        [Authorize(JhIdentityPermissions.IdentityUsers.Default)]
        [HttpGet("{userId}/SuperiorUser")]
        public async Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId)
        {
            return await IdentityUserAppService.GetSuperiorUserAsync(userId);
        }

        //由于每个人都需要改密码所以不使用权限策略
        [Authorize]
        [HttpPost]
        [Route("change-password")]
        public virtual async Task ChangePasswordAsync(ChangePasswordInputDto input)
        {
            await IdentityUserAppService.ChangePasswordAsync(input);
        }
    }
}
