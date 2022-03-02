
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using System.Linq;
using Volo.Abp.Application.Dtos;


namespace Jh.Abp.JhMenu
{
    public class MenuDataSeeder : ITransientDependency, IMenuDataSeeder
    {
        private readonly IMenuAppService menuAppService;
        public MenuDataSeeder(IMenuAppService appService)
        {
            menuAppService = appService;
        }

        public virtual async Task SeedAsync(Guid roleid, MenuRegisterType menuRegisterType, Guid? TenantId = null)
        {
            if (!await menuAppService.AnyAsync(new MenuRetrieveInputDto()))
            {
                await menuAppService.CreateAsync(new MenuCreateInputDto()
                {
                    TenantId= TenantId,
                    MenuCode = "A01",
                    MenuName = "云数据中心",
                    MenuIcon = "fa fa-bars",
                    MenuSort = 1,
                    RoleIds = new Guid[] { roleid }
                });
                await menuAppService.CreateAsync(new MenuCreateInputDto()
                {
                    TenantId= TenantId,
                    MenuCode = "A0101",
                    MenuName = "你的菜单",
                    MenuIcon = "fa fa-bars",
                    MenuSort = 1,
                    MenuParentCode = "A01",
                    MenuUrl = "/main/view/equipmentgroup/index.html",
                    RoleIds = new Guid[] { roleid }
                });
                if ((MenuRegisterType.SystemSetting & menuRegisterType) == MenuRegisterType.SystemSetting)
                {

                    //系统设置
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A02",
                        MenuName = "系统设置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0201",
                        MenuName = "菜单管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/menu/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0202",
                        MenuName = "菜单权限管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/rolemenuand/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0203",
                        MenuName = "接口权限管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/roleinterfaceand/index.html",
                        RoleIds = new Guid[] { roleid },
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0204",
                        MenuName = "用户管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/user/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0205",
                        MenuName = "组织管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/organizationunit/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0206",
                        MenuName = "系统审计日志",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/auditLogging/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0207",
                        MenuName = "系统配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 7,
                        MenuParentCode = "A02",
                        MenuUrl = "/main/view/dictionarydetail/index.html",
                        RoleIds = new Guid[] { roleid }
                    });

                }

                if ((MenuRegisterType.Commodity & menuRegisterType) == MenuRegisterType.Commodity)
                {
                    //商品系统
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A03",
                        MenuName = "商品系统",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0301",
                        MenuName = "商品管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/Commodity/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0302",
                        MenuName = "商品类别",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategory/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0303",
                        MenuName = "商品品牌",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityBrand/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0304",
                        MenuName = "商品标签",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityLabel/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0305",
                        MenuName = "商品排行榜",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityTop/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0306",
                        MenuName = "商品规格模板",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecification/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0307",
                        MenuName = "商品规格模板详情",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 7,
                        MenuParentCode = "A03",
                        MenuUrl = "/main/view/commodity/CommodityCategorySpecificationDetail/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                }

                if ((MenuRegisterType.File & menuRegisterType) == MenuRegisterType.File)
                {
                    //文件系统
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A04",
                        MenuName = "文件系统",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0401",
                        MenuName = "文件管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/file/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0402",
                        MenuName = "文件类别",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/file/filecategory/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                }
                if ((MenuRegisterType.Article & menuRegisterType) == MenuRegisterType.Article)
                {
                    //文章系统
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A05",
                        MenuName = "文章系统",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0501",
                        MenuName = "文章管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A04",
                        MenuUrl = "/main/view/article/article/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0502",
                        MenuName = "文章类别",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleCategory/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0503",
                        MenuName = "文章标签",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 3,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleLable/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0504",
                        MenuName = "资源加锁",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 4,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/RresourceLock/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0505",
                        MenuName = "文章附件管理",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 5,
                        MenuParentCode = "A05",
                        MenuUrl = "/main/view/article/ArticleAccessory/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                }
                if ((MenuRegisterType.WebApp & menuRegisterType) == MenuRegisterType.WebApp)
                {
                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A06",
                        MenuName = "Web配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 6,
                        RoleIds = new Guid[] { roleid }
                    });

                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0601",
                        MenuName = "Web字典配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 1,
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfiguration/index.html",
                        RoleIds = new Guid[] { roleid }
                    });

                    await menuAppService.CreateAsync(new MenuCreateInputDto()
                    {
                        TenantId= TenantId,
                        MenuCode = "A0602",
                        MenuName = "Web字典类别配置",
                        MenuIcon = "fa fa-bars",
                        MenuSort = 2,
                        MenuParentCode = "A06",
                        MenuUrl = "/main/view/webapp/WebDictionaryConfigurationCategory/index.html",
                        RoleIds = new Guid[] { roleid }
                    });
                }
            }
        }
    }
}
