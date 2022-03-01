using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.Authorization.Permissions;
using Microsoft.AspNetCore.Identity;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Account;

namespace Jh.Abp.JhIdentity.v1
{
	/// <summary>
	/// 
	/// </summary>
	[RemoteService]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class IdentityUserController : JhIdentityController
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

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPut("{id}")]
        public virtual async Task<IdentityUserDto> UpdateAsync(System.Guid id, IdentityUserUpdateInputDto input)
        {
            return await IdentityUserAppService.UpdateAsync(id, input);
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

        [Authorize(IdentityPermissions.Users.Create)]
        [Route("items")]
        [HttpPost]
        public virtual async Task CreateAsync(IdentityUserCreateInputDto[] input)
        {
            await IdentityUserAppService.CreateAsync(input);
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [HttpPatch("{id}")]
        public virtual async Task UpdatePortionAsync(System.Guid id, IdentityUserUpdateInputDto inputDto)
        {
            await IdentityUserAppService.UpdatePortionAsync(id, inputDto);
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

        [Authorize(IdentityPermissions.Users.Delete)]
        [HttpDelete]
        public virtual async Task DeleteAsync(IdentityUserDeleteInputDto deleteInputDto)
        {
            await IdentityUserAppService.DeleteAsync(deleteInputDto);
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

        ///// <summary>
        ///// 根据主键删除多条
        ///// </summary>
        ///// <param name="keys"></param>
        ///// <returns></returns>
        //[Authorize(IdentityPermissions.Users.Delete)]
        //[Route("keys")]
        //[HttpDelete]
        //public virtual async Task DeleteAsync([FromBody] Guid[] keys)
        //{
        //    foreach (var item in keys)
        //    {
        //        await UserAppService.DeleteAsync(item);
        //    }
        //}

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
                SelectAction = (query) => query.Where(a => a.UserName != "admin").Select(a => new IdentityUser(a.Id, a.UserName, a.Email, null) { Name = a.Name })
            };
            return await IdentityUserAppService.GetEntitysAsync(inputDto);
        }
    }
}
