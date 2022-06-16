using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public class IdentityUserProfile : Profile
	{
		public IdentityUserProfile()
		{
            CreateMap<IdentityUser, IdentityUserDto>().Ignore(a => a.OrganizationUnitIds).Ignore(a => a.RoleIds)
				;
		}
	}
}
