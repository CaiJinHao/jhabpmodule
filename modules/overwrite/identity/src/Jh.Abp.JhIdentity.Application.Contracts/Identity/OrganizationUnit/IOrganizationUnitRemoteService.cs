using Jh.Abp.Application.Contracts;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public interface IOrganizationUnitRemoteService
		: IRequestRemoteService<OrganizationUnit, OrganizationUnitDto, OrganizationUnitDto, System.Guid, OrganizationUnitRetrieveInputDto, OrganizationUnitCreateInputDto, OrganizationUnitUpdateInputDto, OrganizationUnitDeleteInputDto>
 , IOrganizationUnitBaseAppService
	{
	}
}
