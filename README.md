# JH ABP Module Extension

JH ABP Module Extension 基于[Abp VNext](https://docs.abp.io) 构造的快速开发框架。整合项目开发中常用的基础模块，迅速进入业务开发阶段。配合jhabpadmin使用，前后端分离。包含基础代码生成器。

## 功能介绍

### docs文件夹

这个文件夹主要用于存储项目使用到的一些文档。如设计文件、脚本等

### 类库介绍

* Jh.Abp.Common 公共的操作类库
* Jh.SourceGenerator.Common 代码生成器
* Jh.AbpExtensions 针对Abp的CRUD二次封装
* Jh.Abp.QuickComponents 主启动程序需要引入的一些组件及设置，如默认语言修改、Cors、JSON格式配置、Jwt相关设置、Swagger配置等。
* module_extend 文件夹下是每个模块的功能实现即插即用，可分库及微服务单独部署。
* overwrite 文件夹下是基于abp模块的重写。(使用官方提供的重写服务方法进行重写)

## 使用说明

关于基础使用请移步[AbpVnext](https://docs.abp.io/)或 [Abp VNext For Github](https://github.com/abpframework/abp)

```Use Steps

abp new YourCompany.YourProjectName -t module -d ef -cs "server=127.0.0.1;database=YourProjectDBName;uid=root;pwd=1234565"

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
批量修改名称：JhAbp
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

### 缓存使用注意

1. 缓存雪崩
2. 缓存穿透
3. 缓存击穿

### 查询优化

``` 查询优化
1. 索引建立原则
  a. 频繁搜索的列
  b. 被分组、排序的列
  c. 外键引用列
  d. 建立索引应按照最左匹配原则建立索引
    ⅰ. index(a,b,c)  = index(a) index(a,b) index (a,b,c)
  e. 不适合建立索引
    ⅰ. 重复值较多、查询较少的列不要建立索引。如性别、状态
    ⅱ. 小表不时候建立索引，比如配置表（数量超过300）
  f. 索引的影响
    ⅰ. 索引会影响操作表的性能，因为需要更新索引
  g. 索引应该建立在小字段上，对于大的文本字段不要建立索引
  h. 如果既有单字段索引又有复合索引，应考虑建立单字段索引
  i. 删除无用的索引，避免对执行计划造成影响
2. 表字段创建原则
  a. 尽量使用数字类型字段
  b. 字段不要定义可空字段，使用默认值代替
  c. 对固定格式的字段应使用定长char，节约存储，chart比varchar要快
3. SQL查询优化
  a. 避免全表扫描查询
  b. 避免在where条件对字段进行null值判断，可以使用默认值(0,-1、等)代替null。
    ⅰ. 因为索引不存储null值。
    ⅱ. 查询为null，只能进行全表扫描
  c. 避免使用操作符:   !=、<>、 Like '%_%'、Like '%_'、表达式操作、函数操作、
  d. 避免where条件使用or连接条件，应拆分成多个查询，使用union代替or连接
    ⅰ. 因为会放弃索引，进行全表扫描
  e. 优先使用exists代替 in 和 not in，对于有序的使用between代替in
    ⅰ. in查询，将出现最多的值放在最前面，减少判断的次数
  f. 查询语句尽量不要查询本次业务逻辑使用不到字段。
  g. 尽量使用表别名查询字段，可以减少解析时间。如a.col1,a.col2
  h. 临时表(存储在TempDb数据库)和视图的需求都可以用nosql来处理
  i. 使用exists代替select count(1)判断是否存在记录
    ⅰ. count函数只有统计所有行数时使用
    ⅱ. count(*)可能会锁表
  j. 必要时，SQL可以强制指定索引进行查询，避免全表扫描
  k. 避免使用distionct，使用Group By代替
  l. 查询时应把操作及计算移植操作符右边。如 a.money < 1000/3
```

## Quick Start

请参照 Demo 示例

## 支持

如果你觉得这个仓库还不错，请给一个星 :star:
