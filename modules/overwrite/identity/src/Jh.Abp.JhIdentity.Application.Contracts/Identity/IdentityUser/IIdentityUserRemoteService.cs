using Jh.Abp.Application.Contracts;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public interface IIdentityUserRemoteService
		: IRequestRemoteService<IdentityUser, IdentityUserDto, IdentityUserDto, System.Guid, IdentityUserRetrieveInputDto, IdentityUserCreateInputDto, IdentityUserUpdateInputDto, IdentityUserDeleteInputDto>
 , IIdentityUserBaseAppService
	{
		
	}
}
