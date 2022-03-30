# JH ABP Module Extension

JH ABP Module Extension 基于[Abp VNext](https://docs.abp.io) 构造的快速开发框架。整合项目开发中常用的基础模块，迅速进入业务开发阶段。

## 使用说明

关于基础使用请移步[AbpVnext](https://docs.abp.io/)或 [Abp VNext For Github](https://github.com/abpframework/abp)

```Use Steps
abp new YourCompany.YourProjectName -t module -d ef -cs "server=192.168.12.99;database=test_identity;uid=sa;pwd=12345"

.\addrefrence.ps1 -execPath ..\..\modules\module_extend\menu\ -slnName Jh.Abp.JhMenu

DomainSharedModule添加本地资源继承
    .AddBaseTypes(typeof(Jh.Abp.Domain.Localization.JhAbpExtensionsResource))
    添加模块依赖：typeof(Jh.Abp.Domain.Shared.JhAbpExtensionsDomainSharedModule)

修改appsettings.json参照Demo

IdentityServerModule 修改参照Demo、根据需要更换数据库驱动
    注意添加依赖：
    typeof(JhAbpIdentityServerModule),
    typeof(JhIdentityApplicationModule),
    typeof(JhIdentityEntityFrameworkCoreModule),
    typeof(JhIdentityHttpApiModule),
    typeof(JhMenuApplicationModule),
    typeof(JhMenuEntityFrameworkCoreModule),
    typeof(JhMenuHttpApiModule),
    typeof(AbpQuickComponentsModule)

数据迁移
    添加modelBuilder.ConfigureJhIdentity();
    创建模块迁移数据上下文MenuDbContext，或者可以复制demo中已经创建好的

DataSeedContributor数据播种--批量替换密匙、修改demo中添加todo的地方

xxx.Application.Contracts生成xml，属性=》输出=》xm文档文件路径:[项目名称].Application.Contracts.xml=》生成，将文件设置为嵌入的资源，用于Swagger注释显示

启动程序

HttpApi.Host修改
    修改appsettings.json参照demo
    修改Module
    根据需要添加身份远程服务依赖typeof(JhIdentityHttpApiClientModule),typeof(AbpQuickComponentsModule)


layui-admin 修改
    搜索localhost:60，可进行批量替换
    common.js/oidc-client-sample.js  修改对应的端口、ApiName

```

## 设计

基于[AbpVnext](https://docs.abp.io/)的设计及开发方式进行。

## Quick Start

请参照 Demo 示例

## 支持

如果你觉得这个仓库还不错，请给一个星 :star:
