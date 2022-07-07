using Jh.Abp.Domain;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.TenantManagement
{
	public interface ITenantRepository: ICrudRepository<Tenant, System.Guid>
	{
	}
}
