using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Jh.Abp.JhIdentity.MultiTenancy;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Data;
using Volo.Abp.Emailing;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation.Urls;
using Microsoft.Extensions.Configuration;
using Jh.Abp.QuickComponents.Swagger;
using System.Collections.Generic;
using Jh.Abp.QuickComponents;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Jh.Abp.IdentityServer;
using EntityFrameworkCore.UseRowNumberForPaging;
using Jh.Abp.JhPermission;
using Jh.Abp.Workflow;
using Jh.Abp.JhMenu;
using Volo.Abp.EntityFrameworkCore.MySQL;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpAccountWebIdentityServerModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    //typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(JhIdentityHttpApiModule),
    typeof(JhMenuHttpApiModule),
    typeof(WorkflowHttpApiModule),
    typeof(AbpQuickComponentsModule)
    )]
public class JhIdentityIdentityServerModule : AbpModule
{
    private Microsoft.Extensions.Configuration.IConfiguration configuration;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        configuration = context.Services.GetConfiguration();

        Configure<AbpDbContextOptions>(options =>
        {
            //options.UseSqlServer(options => {
            //    options.UseRowNumberForPaging();//todo:兼容SQLSERVER 2008
            //});
            options.UseMySQL();
        });

        var Audience = configuration.GetValue<string>("AuthServer:ApiName");
        context.Services.AddJhAbpSwagger(configuration,
           new Dictionary<string, string>{
               {Audience, $"{Audience} API"}
           }, contractsType: typeof(JhIdentityApplicationContractsModule));

        //context.Services.AddAbpSwaggerGen(
        //    options =>
        //    {
        //        options.SwaggerDoc("v1", new OpenApiInfo { Title = "JhIdentity API", Version = "v1" });
        //        options.DocInclusionPredicate((docName, description) => true);
        //        options.CustomSchemaIds(type => type.FullName);
        //    });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
        });

        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = "AuthServer";
            options.IsEnabledForAnonymousUsers = false;
            //options.IsEnabledForGetRequests = true;
            //options.EntityHistorySelectors.AddAllEntities();//保存所有的实体更改，将需要大量的存储空间
        });

        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        });

        context.Services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = configuration["AuthServer:ApiName"];
            });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "JhIdentity:";
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("JhIdentity");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "JhIdentity-Protection-Keys");
        }

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif

        context.Services.AddApiVersion();
        //context.Services.AddSameSiteCookiePolicy();//去除https
        context.Services.AddAuthorizeFilter(configuration);//为所有请求添加验证

        //context.Services.AddAlwaysAllowAuthorization();//禁用授权系统方式一
        //禁用授权系统方式二
        //context.Services.Replace(ServiceDescriptor.Singleton<IPermissionChecker, AlwaysAllowPermissionChecker>());

        context.Services.Configure<AbpExceptionHandlingOptions>(options =>
        {
            //配置是否发送错误信息到客户端
            var _b = configuration.GetValue<bool>("AppSettings:SendExceptionsDetailsToClients");
            options.SendExceptionsDetailsToClients = _b;
            options.SendStackTraceToClients = _b;
        });
    }

    public async override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseErrorPage();
            app.UseHsts();
        }

        app.ApplicationServices.InitWorkflowDefinition(workflowHost =>
        {
            //workflowHost.RegisterWorkflow<LeaveApplicationWorkflow, LeaveApplicationWorkflowDto>();
        });

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseJhJwtTokenMiddleware();//todo:modify

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAbpRequestLocalization(options =>
        {
            //默认中文
            options.RequestCultureProviders.RemoveAll(provider => provider is Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider);
        });
        app.UseIdentityServer();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.UseJhSwaggerUiConfig(configuration);
            //options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();

        await SeedData(context);
    }

    private async Task SeedData(ApplicationInitializationContext context)
    {
        using (var scope = context.ServiceProvider.CreateScope())
        {
            var data = scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>();
            var dataSeedContext = new DataSeedContext();
            dataSeedContext["AdminEmail"] = "531003539@qq.com";
            dataSeedContext["AdminPassword"] = "KimHo@123";
            var roleService = scope.ServiceProvider.GetRequiredService<IIdentityRoleRepository>();
            var roles = await roleService.GetListAsync();
            if (roles.Count > 0)
            {
                dataSeedContext["RoleId"] = roles.FirstOrDefault()?.Id;//IdentityServerHost创建的角色ID

                //菜单依赖
                //dataSeedContext["MenuRegisterType"] = MenuRegisterType.SystemSetting | MenuRegisterType.Commodity | MenuRegisterType.Article | MenuRegisterType.File | MenuRegisterType.WebApp;
            }
            await data.SeedAsync(dataSeedContext);
        }
    }
}
