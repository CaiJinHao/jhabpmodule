using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IdentityUserStore))]
    public class IdentityUserStoreOverride : IdentityUserStore, ITransientDependency
    {
        public IdentityUserStoreOverride(Volo.Abp.Identity.IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository, IGuidGenerator guidGenerator, ILogger<IdentityRoleStore> logger, ILookupNormalizer lookupNormalizer, IdentityErrorDescriber describer = null) : base(userRepository, roleRepository, guidGenerator, logger, lookupNormalizer, describer)
        {
        }

        /// <summary>
        /// 针对用户组织的处理
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IList<string>> GetRolesAsync(Volo.Abp.Identity.IdentityUser user, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Check.NotNull(user, nameof(user));

            var userRoles = await UserRepository
                .GetRoleNamesAsync(user.Id, cancellationToken: cancellationToken);
            return userRoles;
        }
    }
}
