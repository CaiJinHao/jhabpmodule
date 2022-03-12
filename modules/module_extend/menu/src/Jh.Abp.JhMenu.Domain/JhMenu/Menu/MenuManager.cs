
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
                await CreateAsync(new Menu(TenantId)
                {
                    MenuCode = "A01",
                    MenuName = "����������",
                    MenuIcon = "fa fa-bars",
                    MenuSort = 1,
                });
                await CreateAsync(new Menu(TenantId)
                {
                    MenuCode = "A0101",
                    MenuName = "��Ĳ˵�",
                    MenuIcon = "fa fa-bars",
                    MenuSort = 1,
                    MenuParentCode = "A01",
                    MenuUrl = "/main/view/equipmentgroup/index.html",
                });
                if ((MenuRegisterType.SystemSetting & menuRegisterType) == MenuRegisterType.SystemSetting)
                {
                    //ϵͳ����
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A02",
                        MenuName = "ϵͳ����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0201",
                        MenuName = "�˵�����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/menu/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0202",
                        MenuName = "�˵�Ȩ�޹���",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/rolemenuand/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0203",
                        MenuName = "�ӿ�Ȩ�޹���",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/roleinterfaceand/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0204",
                        MenuName = "�û�����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/user/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0205",
                        MenuName = "��֯����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/organizationunit/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0206",
                        MenuName = "ϵͳ�����־",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
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
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A03",
                        MenuName = "��Ʒϵͳ",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0301",
                        MenuName = "��Ʒ����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/Commodity/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0302",
                        MenuName = "��Ʒ���",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategory/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0303",
                        MenuName = "��ƷƷ��",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityBrand/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0304",
                        MenuName = "��Ʒ��ǩ",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityLabel/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0305",
                        MenuName = "��Ʒ���а�",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityTop/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0306",
                        MenuName = "��Ʒ���ģ��",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecification/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0307",
                        MenuName = "��Ʒ���ģ������",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 7,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecificationDetail/index.html",
                    });
                }

                if ((MenuRegisterType.File & menuRegisterType) == MenuRegisterType.File)
                {
                    //�ļ�ϵͳ
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A04",
                        MenuName = "�ļ�ϵͳ",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0401",
                        MenuName = "�ļ�����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/file/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0402",
                        MenuName = "�ļ����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/filecategory/index.html",
                    });
                }
                if ((MenuRegisterType.Article & menuRegisterType) == MenuRegisterType.Article)
                {
                    //����ϵͳ
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A05",
                        MenuName = "����ϵͳ",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0501",
                        MenuName = "���¹���",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/article/article/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0502",
                        MenuName = "�������",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleCategory/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0503",
                        MenuName = "���±�ǩ",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleLable/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0504",
                        MenuName = "��Դ����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/RresourceLock/index.html",
                    });
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0505",
                        MenuName = "���¸�������",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleAccessory/index.html",
                    });
                }
                if ((MenuRegisterType.WebApp & menuRegisterType) == MenuRegisterType.WebApp)
                {
                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A06",
                        MenuName = "Web����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                    });

                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0601",
                        MenuName = "Web�ֵ�����",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfiguration/index.html",
                    });

                    await CreateAsync(new Menu(TenantId)
                    {
                        MenuCode = "A0602",
                        MenuName = "Web�ֵ��������",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfigurationCategory/index.html",
                    });
                }
            }
            return Menus;
        }
    }
}
