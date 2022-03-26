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

IdentityServerModule 修改参照Demo
    注意添加依赖、typeof(JhIdentityHttpApiModule),typeof(AbpQuickComponentsModule)

数据迁移
    添加modelBuilder.ConfigureJhIdentity();

DataSeedContributor数据播种--批量替换密匙、添加JsClient

xxx.Application.Contracts.xml生成，设置为嵌入的资源，用于Swagger注释显示

启动程序

Host添加其他模块
引用MenuHttpApi、Ef、Application 添加依赖、创建数据迁移即可

远程服务
引用HttpApi.Client,添加依赖


layui-admin 修改
    common.js/oidc-client-sample.js  修改对应的端口、ApiName

```

## 设计

基于[AbpVnext](https://docs.abp.io/)的设计及开发方式进行。

## Quick Start

请参照 Demo 示例

## 支持

如果你觉得这个仓库还不错，请给一个星 :star:
