using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Data;

namespace Jh.Abp.JhIdentity
{
	public class OrganizationUnitProfile : Profile
	{
		public OrganizationUnitProfile()
		{
		CreateMap<OrganizationUnit,OrganizationUnitDto>();
		CreateMap<OrganizationUnitCreateInputDto, OrganizationUnit>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a=>a.Code)
				.Ignore(a=>a.Roles)
;
		CreateMap<OrganizationUnitUpdateInputDto, OrganizationUnit>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a=>a.Code)
				.Ignore(a=>a.TenantId)
				.Ignore(a=>a.Roles)
;
		}
	}
}
