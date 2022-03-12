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
            CreateMap<OrganizationUnit, OrganizationUnitDto>();
        }
    }
}
