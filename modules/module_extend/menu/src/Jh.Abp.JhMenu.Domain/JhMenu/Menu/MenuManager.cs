
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Jh.Abp.JhMenu
{
    public class MenuManager : DomainService
    {
        protected IMenuRepository MenuRepository => LazyServiceProvider.LazyGetRequiredService<IMenuRepository>();
        private List<Menu> Menus { get; set; } = new List<Menu>();
        protected async Task CreateAsync(Menu menu)
        {
            menu.MenuDescription = menu.MenuName;
            var data= await MenuRepository.CreateAsync(menu,true);
            Menus.Add(data);
        }

        public virtual async Task<List<Menu>> InitMenuAsync(Guid? TenantId)
        {
            var menuRegisterType = JhMenuConsts.MenuRegisterType;
            var menuQueryable = await MenuRepository.GetQueryableAsync();
            if (TenantId.HasValue)
            {
                menuQueryable = menuQueryable.Where(a => a.TenantId == TenantId);
            }
            var exist = menuQueryable.Any();
            if (!exist)
            {
                var rootSort = 0;
                await CreateAsync(new Menu("A01", "����������", "fa fa-bars", ++rootSort, TenantId));
                await CreateAsync(new Menu("A0101", "��Ĳ˵�", "fa fa-bars", 1, TenantId)
                {
                    MenuParentCode = "A01",
                    MenuUrl = "/main/view/equipmentgroup/index.html",
                });

                if ((MenuRegisterType.SystemSetting & menuRegisterType) == MenuRegisterType.SystemSetting)
                {
                    //ϵͳ����
                    await CreateAsync(new Menu("A02", "ϵͳ����", "fa fa-bars", +rootSort, TenantId));

                    var childSort = 0;
                    await CreateAsync(new Menu("A0201", "�˵�����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/menu/index.html",
                    });
                    await CreateAsync(new Menu("A0202", "�˵�Ȩ�޹���", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/rolemenuand/index.html",
                    });
                    await CreateAsync(new Menu("A0203", "�ӿ�Ȩ�޹���", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/roleinterfaceand/index.html",
                    });
                    await CreateAsync(new Menu("A0204", "�û�����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/user/index.html",
                    });
                    await CreateAsync(new Menu("A0205", "��֯����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/organizationunit/index.html",
                    });
                    await CreateAsync(new Menu("A0206", "ϵͳ�����־", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/auditLogging/index.html",
                    });

                    //await CreateAsync(new Menu(TenantId)
                    //{
                    //    MenuCode = "A0207",
                    //    MenuName = "ϵͳ����",
                    //    MenuIcon = "fa fa-bars",
                    //    MenuSort = 7,
                    //    MenuParentCode = "A02",
                    //    MenuUrl = "/main/view/dictionarydetail/index.html",
                    //});

                }

                if ((MenuRegisterType.Commodity & menuRegisterType) == MenuRegisterType.Commodity)
                {
                    //��Ʒϵͳ
                    await CreateAsync(new Menu("A03", "��Ʒϵͳ", "fa fa-bars", ++rootSort, TenantId));
                    var childSort = 0;
                    await CreateAsync(new Menu("A0301", "��Ʒ����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/Commodity/index.html",
                    });
                    await CreateAsync(new Menu("A0302", "��Ʒ���", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategory/index.html",
                    });
                    await CreateAsync(new Menu("A0303", "��ƷƷ��", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityBrand/index.html",
                    });
                    await CreateAsync(new Menu("A0304", "��Ʒ��ǩ", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityLabel/index.html",
                    });
                    await CreateAsync(new Menu("A0305", "��Ʒ���а�", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityTop/index.html",
                    });
                    await CreateAsync(new Menu("A0306", "��Ʒ���ģ��", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecification/index.html",
                    });
                    await CreateAsync(new Menu("A0307", "��Ʒ���ģ������", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecificationDetail/index.html",
                    });
                }

                if ((MenuRegisterType.File & menuRegisterType) == MenuRegisterType.File)
                {
                    //�ļ�ϵͳ
                    await CreateAsync(new Menu("A04", "�ļ�ϵͳ", "fa fa-bars", ++rootSort, TenantId));

                    var childSort = 0;
                    await CreateAsync(new Menu("A0401", "�ļ�����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/file/index.html",
                    });
                    await CreateAsync(new Menu("A0402", "�ļ����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/filecategory/index.html",
                    });
                }
                if ((MenuRegisterType.Article & menuRegisterType) == MenuRegisterType.Article)
                {
                    //����ϵͳ
                    await CreateAsync(new Menu("A05", "����ϵͳ", "fa fa-bars", ++rootSort, TenantId));
                   
                    var childSort = 0;
                    await CreateAsync(new Menu("A0501", "���¹���", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/article/article/index.html",
                    });
                    await CreateAsync(new Menu("A0502", "�������", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleCategory/index.html",
                    });
                    await CreateAsync(new Menu("A0503", "���±�ǩ", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleLable/index.html",
                    });
                    await CreateAsync(new Menu("A0504", "��Դ����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/RresourceLock/index.html",
                    });
                    await CreateAsync(new Menu("A0505", "���¸�������", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleAccessory/index.html",
                    });
                }
                if ((MenuRegisterType.WebApp & menuRegisterType) == MenuRegisterType.WebApp)
                {
                    await CreateAsync(new Menu("A06", "Web����", "fa fa-bars", ++rootSort, TenantId));

                    var childSort = 0;
                    await CreateAsync(new Menu("A0601", "Web�ֵ�����", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfiguration/index.html",
                    });

                    await CreateAsync(new Menu("A0602", "Web�ֵ��������", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfigurationCategory/index.html",
                    });
                }
            }
            return Menus;
        }
    }
}
