using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.JhMenu
{
	public class MenuRoleMapProfile : Profile
	{
		public MenuRoleMapProfile()
		{
		CreateMap<MenuRoleMap,MenuRoleMapDto>();
//		CreateMap<MenuRoleMapCreateInputDto, MenuRoleMap>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id)
//				.Ignore(a=>a.Menu)
//;
//		CreateMap<MenuRoleMapUpdateInputDto, MenuRoleMap>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id)
//				.Ignore(a=>a.Menu)
//;
		}
	}
}
