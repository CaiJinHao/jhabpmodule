using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Data;
using System.Linq;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitProfile : Profile
    {
        public OrganizationUnitProfile()
        {
            CreateMap<OrganizationUnit, OrganizationUnitDto>()
                .ForMember(dest => dest.RoleIds, option => option.MapFrom(src => src.Roles.Select(a => a.RoleId).ToArray()))
                .Ignore(a => a.LeaderId)
                .Ignore(a => a.LeaderName)
                .Ignore(a => a.LeaderType)
                ;
        }
    }
}
