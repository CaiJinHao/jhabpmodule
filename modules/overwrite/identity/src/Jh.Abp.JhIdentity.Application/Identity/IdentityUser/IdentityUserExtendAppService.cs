using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	[Obsolete("暂时没有要重写的方法")]
    public class IdentityUserExtendAppService : Volo.Abp.Identity.IdentityUserAppService
    {
        public IdentityUserExtendAppService(IdentityUserManager userManager, Volo.Abp.Identity.IIdentityUserRepository userRepository, Volo.Abp.Identity.IIdentityRoleRepository roleRepository, IOptions<IdentityOptions> identityOptions) : base(userManager, userRepository, roleRepository, identityOptions)
        {
        }
    }
}
