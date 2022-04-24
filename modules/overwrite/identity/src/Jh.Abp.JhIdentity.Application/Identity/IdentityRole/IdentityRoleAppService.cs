using Jh.Abp.Application;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleAppService
		: CrudApplicationService<IdentityRole, IdentityRoleDto, IdentityRoleDto, System.Guid, IdentityRoleRetrieveInputDto, IdentityRoleCreateInputDto, IdentityRoleUpdateInputDto, IdentityRoleDeleteInputDto>,
		IJhIdentityRoleAppService
	{
		private readonly IJhIdentityRoleRepository IdentityRoleRepository;
		private readonly IIdentityRoleDapperRepository IdentityRoleDapperRepository;
		public JhIdentityRoleAppService(IJhIdentityRoleRepository repository, IIdentityRoleDapperRepository identityroleDapperRepository) : base(repository)
		{
		IdentityRoleRepository = repository;
		IdentityRoleDapperRepository = identityroleDapperRepository;
		}

        public async Task<Guid?> GetAdminRoleIdAsync()
        {
            var role = await (await IdentityRoleRepository.GetQueryableAsync()).AsNoTracking().FirstOrDefaultAsync(a => a.Name == JhIdentity.JhIdentityConsts.AdminRoleName);
            if (role!=null)
            {
				return role.Id;
            }
			return null;
        }
    }
}
