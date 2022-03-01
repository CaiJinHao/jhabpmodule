using Jh.Abp.Domain.Extensions;
using System;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public interface IJhIdentityRoleRepository: ICrudRepository<IdentityRole, System.Guid>
	{
	}
}
