# 使用步骤

## 使用abp脚手架下载模板项目

 abp new MyDemo -t module -d ef -cs "server=127.0.0.1;database=demo;uid=sa;pwd=Jh@123456"  

## 添加依赖包

使用 https://gitee.com/CaiJinHao/jhabpmodule/blob/dev/docs/shell/initprojectref.ps1 添加依赖包  
./initprojectref.ps1 -execPath E:\mycode\jhabpdemo\web -slnName MyDemo  

## IdentityServer修改

### DomainSharedModule

``` C#
//在MyDemoDomainSharedModule修改
[DependsOn(
    typeof(Jh.Abp.Domain.Shared.JhAbpExtensionsDomainSharedModule),
    typeof(AbpValidationModule)
)]

Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<MyDemoResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(Jh.Abp.Domain.Localization.JhAbpExtensionsResource))
                .AddVirtualJson("/Localization/MyDemo");
        });
```

### IdentityServerModule

[参照配置](https://gitee.com/CaiJinHao/jhabpmodule/blob/dev/modules/overwrite/identity/host/Jh.Abp.JhIdentity.IdentityServer/JhIdentityIdentityServerModule.cs)

``` C#
//在MyDemoIdentityServerModule添加依赖
typeof(JhAbpIdentityServerModule),
    typeof(JhIdentityApplicationModule),
    typeof(JhIdentityEntityFrameworkCoreModule),
    typeof(JhIdentityHttpApiModule),
    typeof(AbpQuickComponentsModule),

//在IdentityServerHostMigrationsDbContext添加
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigurePermissionManagement();
        modelBuilder.ConfigureSettingManagement();
        modelBuilder.ConfigureAuditLogging();
        modelBuilder.ConfigureIdentity();
        modelBuilder.ConfigureIdentityServer();
        modelBuilder.ConfigureFeatureManagement();
        modelBuilder.ConfigureTenantManagement();

        modelBuilder.ConfigureJhIdentity();
    }

//为MyDemo.Application.Contracts 添加xml文档,并将生成后的xml文档设置为嵌入的资源
//打开类库属性=》输出=》文档文件=》勾选生成包含API文档文件=》填写MyDemo.Application.Contracts.xml=>生成当前类库=》右键生成的文件=》生成操作=》嵌入的资源

```

### 使用修改后的Pages

[复制文件到你的Pages下.](https://gitee.com/CaiJinHao/jhabpmodule/tree/dev/modules/overwrite/identity/host/Jh.Abp.JhIdentity.IdentityServer/Pages)  
[复制文件到你的wwwroot下.](https://gitee.com/CaiJinHao/jhabpmodule/tree/dev/modules/overwrite/identity/host/Jh.Abp.JhIdentity.IdentityServer/wwwroot)  

### 修改appsettings

[参照appsettings配置](https://gitee.com/CaiJinHao/jhabpmodule/blob/dev/modules/overwrite/identity/host/Jh.Abp.JhIdentity.IdentityServer/appsettings.json)  

## 准备数据库

``` shell
  docker pull mcr.microsoft.com/mssql/server:2022-latest
  docker run -d --name mssqlserver -p 1433:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Jh@123456" -t mcr.microsoft.com/mssql/server:2022-latest
  # 迁移数据库，删除Migrations文件夹,在当前文件夹打开powershell或者其他终端
  dotnet ef migrations add initial
  dotnet ef database update
```

### 启动IdentityServer

``` shell
dotnet run
# 登录测试 https://localhost:44355/account/login 
# account: admin  pwd:JinHao@123
# swagger: https://localhost:44355/swagger/index.html
```

## HttpApi.Host修改

[参照appsettings配置]()

## admin

``` shell
git clone https://gitee.com/CaiJinHao/jhabpadmin.git
# 使用[jhabpadmin](https://gitee.com/CaiJinHao/jhabpadmin/tree/dev/jhabpadmin)
# 执行yarn 
# 修改配置
# 找到 environment.ts文件，修改为你的配置
# configEnv.api = 'https://localhost:44385/';
# configEnv.identityApi = 'https://localhost:44322/';
# configEnv.clientId = 'MyDemo_App';
# scope: 'offline_access MyDemo',
# 执行yarn start
# 首页地址：http://localhost:4200/
```
