# JH ABP Module Extension

JH ABP Module Extension 基于[Abp VNext](https://docs.abp.io) 构造的快速开发框架。整合项目开发中常用的基础模块，迅速进入业务开发阶段。  

## 使用说明

关于基础使用请移步[AbpVnext](https://docs.abp.io/)或 [Abp VNext For Github](https://github.com/abpframework/abp)

``` Use Steps
abp new YourCompany.YourProjectName -t module -d ef -cs "server=192.168.12.99;database=test_identity;uid=sa;pwd=12345"  

.\addrefrence.ps1 -execPath ..\..\modules\module_extend\menu\ -slnName Jh.Abp.JhMenu  

修改appsettings.json参照Demo  

Module 修改参照Demo  
    注意添加依赖、typeof(JhIdentityHttpApiModule),typeof(AbpQuickComponentsModule)  

数据迁移  

DataSeedContributor数据播种--批量替换密匙、添加JsClient  

Contracts.xml生成，设置为嵌入的资源，用于Swagger注释显示  


```

## 设计

借鉴[AbpVnext](https://docs.abp.io/)的设计及开发方式进行。

## Quick Start

请参照Demo

## Support the ABP Framework

如果你觉得这个仓库还不错，请给一个星 :star:
