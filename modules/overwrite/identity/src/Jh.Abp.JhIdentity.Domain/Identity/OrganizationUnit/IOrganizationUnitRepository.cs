using Jh.Abp.Domain.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public interface IOrganizationUnitRepository: ICrudRepository<OrganizationUnit, System.Guid>
	{
	}
}
