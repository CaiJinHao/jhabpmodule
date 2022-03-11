using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.JhMenu
{
    public class MenuDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        protected IMenuRepository menuRepository { get; }
        protected MenuManager menuManager { get; }
        public MenuDataSeedContributor(MenuManager MenuManager, IMenuRepository MenuRepository, MenuRoleMapManager MenuRoleMapManager, IMenuRoleMapRepository MenuRoleMapRepository)
        {
            menuManager = MenuManager;
            menuRepository = MenuRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var menuRegisterType = JhMenuConsts.MenuRegisterType;
            if (!(await menuRepository.GetQueryableAsync()).Any())
            {
                await menuManager.CreateAsync(new Menu()
                {

                    MenuCode = "A01",
                    MenuName = "云数据中心",
                    MenuIcon = "fa fa-bars",
                    MenuSort = 1,
                });
                await menuManager.CreateAsync(new Menu()
                {

                    MenuCode = "A0101",
                    MenuName = "你的菜单",
                    MenuIcon = "fa fa-bars",
                    MenuSort = 1,
                    MenuParentCode = "A01",
                    MenuUrl = "/main/view/equipmentgroup/index.html",
                });
                if ((MenuRegisterType.SystemSetting & menuRegisterType) == MenuRegisterType.SystemSetting)
                {

                    //系统设置
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A02",
                        MenuName = "系统设置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0201",
                        MenuName = "菜单管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/menu/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0202",
                        MenuName = "菜单权限管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/rolemenuand/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0203",
                        MenuName = "接口权限管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/roleinterfaceand/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0204",
                        MenuName = "用户管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/user/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0205",
                        MenuName = "组织管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/organizationunit/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0206",
                        MenuName = "系统审计日志",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/auditLogging/index.html",
                    });

                    //await menuManager.CreateAsync(new Menu()
                    //{
                    //    TenantId= TenantId,
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
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A03",
                        MenuName = "商品系统",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0301",
                        MenuName = "商品管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/Commodity/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0302",
                        MenuName = "商品类别",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategory/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0303",
                        MenuName = "商品品牌",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityBrand/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0304",
                        MenuName = "商品标签",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityLabel/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0305",
                        MenuName = "商品排行榜",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityTop/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0306",
                        MenuName = "商品规格模板",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecification/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0307",
                        MenuName = "商品规格模板详情",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 7,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecificationDetail/index.html",
                    });
                }

                if ((MenuRegisterType.File & menuRegisterType) == MenuRegisterType.File)
                {
                    //文件系统
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A04",
                        MenuName = "文件系统",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0401",
                        MenuName = "文件管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/file/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0402",
                        MenuName = "文件类别",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/filecategory/index.html",
                    });
                }
                if ((MenuRegisterType.Article & menuRegisterType) == MenuRegisterType.Article)
                {
                    //文章系统
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A05",
                        MenuName = "文章系统",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0501",
                        MenuName = "文章管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/article/article/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0502",
                        MenuName = "文章类别",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleCategory/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0503",
                        MenuName = "文章标签",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleLable/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0504",
                        MenuName = "资源加锁",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/RresourceLock/index.html",
                    });
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0505",
                        MenuName = "文章附件管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleAccessory/index.html",
                    });
                }
                if ((MenuRegisterType.WebApp & menuRegisterType) == MenuRegisterType.WebApp)
                {
                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A06",
                        MenuName = "Web配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                    });

                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0601",
                        MenuName = "Web字典配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfiguration/index.html",
                    });

                    await menuManager.CreateAsync(new Menu()
                    {

                        MenuCode = "A0602",
                        MenuName = "Web字典类别配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfigurationCategory/index.html",
                    });
                }
            }
        }
    }
}
