
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
                await CreateAsync(new Menu("A01", "云数据中心", "fa fa-bars", ++rootSort, TenantId));
                await CreateAsync(new Menu("A0101", "你的菜单", "fa fa-bars", 1, TenantId)
                {
                    MenuParentCode = "A01",
                    MenuUrl = "/main/view/equipmentgroup/index.html",
                });

                if ((MenuRegisterType.SystemSetting & menuRegisterType) == MenuRegisterType.SystemSetting)
                {
                    //系统设置
                    await CreateAsync(new Menu("A02", "系统设置", "fa fa-bars", +rootSort, TenantId));

                    var childSort = 0;
                    await CreateAsync(new Menu("A0201", "菜单管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/menu/index.html",
                    });
                    await CreateAsync(new Menu("A0202", "菜单权限管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/rolemenuand/index.html",
                    });
                    await CreateAsync(new Menu("A0203", "接口权限管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/roleinterfaceand/index.html",
                    });
                    await CreateAsync(new Menu("A0204", "用户管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/user/index.html",
                    });
                    await CreateAsync(new Menu("A0205", "组织管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/organizationunit/index.html",
                    });
                    await CreateAsync(new Menu("A0206", "系统审计日志", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/auditLogging/index.html",
                    });

                    //await CreateAsync(new Menu(TenantId)
                    //{
                    //    MenuCode = "A0207",
                    //    MenuName = "系统配置",
                    //    MenuIcon = "fa fa-bars",
                    //    MenuSort = 7,
                    //    MenuParentCode = "A02",
                    //    MenuUrl = "/main/view/dictionarydetail/index.html",
                    //});

                }

                if ((MenuRegisterType.Commodity & menuRegisterType) == MenuRegisterType.Commodity)
                {
                    //商品系统
                    await CreateAsync(new Menu("A03", "商品系统", "fa fa-bars", ++rootSort, TenantId));
                    var childSort = 0;
                    await CreateAsync(new Menu("A0301", "商品管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/Commodity/index.html",
                    });
                    await CreateAsync(new Menu("A0302", "商品类别", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategory/index.html",
                    });
                    await CreateAsync(new Menu("A0303", "商品品牌", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityBrand/index.html",
                    });
                    await CreateAsync(new Menu("A0304", "商品标签", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityLabel/index.html",
                    });
                    await CreateAsync(new Menu("A0305", "商品排行榜", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityTop/index.html",
                    });
                    await CreateAsync(new Menu("A0306", "商品规格模板", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecification/index.html",
                    });
                    await CreateAsync(new Menu("A0307", "商品规格模板详情", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecificationDetail/index.html",
                    });
                }

                if ((MenuRegisterType.File & menuRegisterType) == MenuRegisterType.File)
                {
                    //文件系统
                    await CreateAsync(new Menu("A04", "文件系统", "fa fa-bars", ++rootSort, TenantId));

                    var childSort = 0;
                    await CreateAsync(new Menu("A0401", "文件管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/file/index.html",
                    });
                    await CreateAsync(new Menu("A0402", "文件类别", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/filecategory/index.html",
                    });
                }
                if ((MenuRegisterType.Article & menuRegisterType) == MenuRegisterType.Article)
                {
                    //文章系统
                    await CreateAsync(new Menu("A05", "文章系统", "fa fa-bars", ++rootSort, TenantId));
                   
                    var childSort = 0;
                    await CreateAsync(new Menu("A0501", "文章管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/article/article/index.html",
                    });
                    await CreateAsync(new Menu("A0502", "文章类别", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleCategory/index.html",
                    });
                    await CreateAsync(new Menu("A0503", "文章标签", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleLable/index.html",
                    });
                    await CreateAsync(new Menu("A0504", "资源加锁", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/RresourceLock/index.html",
                    });
                    await CreateAsync(new Menu("A0505", "文章附件管理", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleAccessory/index.html",
                    });
                }
                if ((MenuRegisterType.WebApp & menuRegisterType) == MenuRegisterType.WebApp)
                {
                    await CreateAsync(new Menu("A06", "Web配置", "fa fa-bars", ++rootSort, TenantId));

                    var childSort = 0;
                    await CreateAsync(new Menu("A0601", "Web字典配置", "fa fa-bars", ++childSort, TenantId)
                    {
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfiguration/index.html",
                    });

                    await CreateAsync(new Menu("A0602", "Web字典类别配置", "fa fa-bars", ++childSort, TenantId)
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
