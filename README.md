# JH ABP Module Extension

JH ABP Module Extension 基于[Abp VNext](https://docs.abp.io) 构造的快速开发框架。整合项目开发中常用的基础模块，迅速进入业务开发阶段。

## 使用说明

关于基础使用请移步[AbpVnext](https://docs.abp.io/)或 [Abp VNext For Github](https://github.com/abpframework/abp)

```Use Steps

abp new YourCompany.YourProjectName -t module -d ef -cs "server=127.0.0.1;database=EquipmentManagement;uid=root;pwd=1234565"

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
    typeof(AbpQuickComponentsModule)
    参照Demo修改

数据迁移修改
    MigrationsDbContext添加modelBuilder.ConfigureJhIdentity();

DataSeedContributor数据播种--批量替换密匙、修改demo中添加todo的地方

xxx.Application.Contracts生成xml，属性=》输出=》xm文档文件路径:[项目名称].Application.Contracts.xml=》生成，将文件设置为嵌入的资源，用于Swagger注释显示

修改Pages
    将Account文件夹和Layouts文件夹Copy到你的项目

删除Migrations，重新创建迁移
    dotnet ef migrations add initial
    dotnet ef database update

css
   把wwwroot下的文件Copy到你的项目
    
启动程序

下载前端代码：git clone -b  dev  jhabpadmin
安装依赖：yarn
修改environments配置
批量修改系统名称：JH Abp Admin 
批量修改公司名称：金浩出品必属精品
修改logo: 将public文件下logo.png替换
替换favicon.ico
删除public下无用的文件
创建业务模块文件夹（可随意添加）：
如：moudles
启动项目：yarn start


layui-admin 修改（已不再更新维护，请使用antdpro前端）
    搜索localhost:60，可进行批量替换
    common.js/oidc-client-sample.js  修改对应的端口、ApiName

HttpApi.Host修改
    修改appsettings.json参照demo
    修改Module
    根据需要添加身份远程服务依赖typeof(JhIdentityHttpApiClientModule),typeof(AbpQuickComponentsModule)
如果有用到远程服务，再Application层添加xxxContractsModule依赖，如依赖用户模块：typeof(JhIdentityApplicationContractsModule),
在ApplicationContractsModule添加typeof(JhAbpContractsModule),
在EntityFrameworkCoreModule添加typeof(JhAbpEntityFrameworkCoreModule),

数据库设计：
创建模块文件夹
    创建Domain文件夹
        创建SubDomain文件夹、创建SubDomain类（根据OOM生成类）
添加数据上下文及Model映射（根据PDM生成映射C#代码）
    添加Domain中外键，及关系
    如：
b.HasMany<EquipmentGroup>().WithOne().HasForeignKey(eg => eg.ParentId);
b.HasMany(eg => eg.EquipmentGroupEquipments).WithOne().HasForeignKey(ege => ege.EquipmentGroupId);
b.HasOne<EquipmentGroup>().WithMany().HasForeignKey(ege => ege.EquipmentGroupId).IsRequired();
b.HasIndex(ege => new { ege.EquipmentGroupId, ege.EquipmentId });
    添加或者去除Domain中多余字段
生成底层CRUD代码(中间表不需要CRUD)
生成AntdPro前端CRUD代码


```

## 开发

创建CDM、审计属性无需创建、小数字段类型长度使用18
通过CMD生成PDM
通过PDM生成OOM（注意选择去掉name into codes）、根据OOM创建Domain类（根据需要修改为聚合根、聚合、实体）
通过PDM生成数据库映射、根据需求修改相关外键字段
通过单元测试生成基础设施（参考demo）

## 开发过程注意

根据SQL查询需要添加数据库索引

## 设计

基于[AbpVnext](https://docs.abp.io/)的设计及开发方式进行。

## Quick Start

请参照 Demo 示例

## 支持

如果你觉得这个仓库还不错，请给一个星 :star:
