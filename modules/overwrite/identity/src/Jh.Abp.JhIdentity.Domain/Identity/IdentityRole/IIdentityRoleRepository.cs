using Jh.Abp.Domain;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IJhIdentityRoleRepository: ICrudRepository<IdentityRole, System.Guid>
	{
	}
}
