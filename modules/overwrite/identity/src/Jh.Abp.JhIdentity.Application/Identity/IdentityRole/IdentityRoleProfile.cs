using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public class IdentityRoleProfile : Profile
	{
		public IdentityRoleProfile()
		{
		CreateMap<IdentityRole,IdentityRoleDto>();
		CreateMap<IdentityRoleCreateInputDto, IdentityRole>().Ignore(a => a.Id)
				.Ignore(a=>a.Claims)
;
		CreateMap<IdentityRoleUpdateInputDto, IdentityRole>().Ignore(a => a.Id)
				.Ignore(a=>a.Claims)
;
		}
	}
}
