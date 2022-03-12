using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.JhMenu
{
	public class MenuProfile : Profile
	{
		public MenuProfile()
		{
		CreateMap<Menu,MenuDto>().MapExtraProperties();
		CreateMap<MenuCreateInputDto, Menu>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a=>a.TenantId)
				.Ignore(a=>a.MenuRoleMap)
;
		CreateMap<MenuUpdateInputDto, Menu>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a => a.TenantId)
				.Ignore(a=>a.MenuRoleMap)
;
		}
	}
}
