using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Utils;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
namespace Jh.Abp.JhIdentity
{
    public interface IJhIdentityRoleAppService
		: ICrudApplicationService<IdentityRole, IdentityRoleDto, IdentityRoleDto, System.Guid, IdentityRoleRetrieveInputDto, IdentityRoleCreateInputDto, IdentityRoleUpdateInputDto, IdentityRoleDeleteInputDto>
	{
		Task<Guid?> GetAdminRoleIdAsync();
		Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name);
	}
}
