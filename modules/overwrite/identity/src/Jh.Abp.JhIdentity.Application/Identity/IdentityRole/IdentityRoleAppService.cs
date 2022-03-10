using Jh.Abp.Application;
using Volo.Abp.Identity;

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
	}
}
