using Jh.Abp.IdentityServer;
using Jh.Abp.JhIdentity.Localization;
using Jh.Abp.JhIdentity.MongoDB;
using Jh.Abp.JhIdentity.MultiTenancy;
using Jh.Abp.QuickComponents;
using Jh.Abp.QuickComponents.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Data;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.MongoDB;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.IdentityServer.MongoDB;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.MongoDB;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.MongoDB;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Localization;
using Volo.Abp.TenantManagement.MongoDB;
using Volo.Abp.UI.Navigation.Urls;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpAccountWebIdentityServerModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpAuditLoggingMongoDbModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpIdentityMongoDbModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpIdentityServerMongoDbModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementMongoDbModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementMongoDbModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpFeatureManagementMongoDbModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpTenantManagementMongoDbModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),

    typeof(JhAbpIdentityServerModule),
    typeof(JhIdentityApplicationModule),
    typeof(JhIdentityMongoDbModule),
    typeof(JhIdentityHttpApiModule),
    //typeof(WorkflowHttpApiModule),
    typeof(AbpQuickComponentsModule)
    )]
public class JhIdentityIdentityServerModule : AbpModule
{
    private Microsoft.Extensions.Configuration.IConfiguration configuration;

    private void ConfigureLocalizationOptions()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<JhIdentityResource>()
                .AddBaseTypes(typeof(Volo.Abp.Identity.Localization.IdentityResource));

            options.Resources
                .Get<AbpTenantManagementResource>()
                .AddVirtualJson("/Localization/JhAbpExtensions")//使用虚拟路径加载，并覆盖资源得键值对
               ;

            options.Resources
                .Get<Volo.Abp.Identity.Localization.IdentityResource>()
                .AddVirtualJson("/Localization/JhIdentity")
                .AddVirtualJson("/Localization/JhAbpExtensions")//使用虚拟路径加载，并覆盖资源得键值对
               ;

            options.Resources
                .Get<Volo.Abp.SettingManagement.Localization.AbpSettingManagementResource>()
                .AddVirtualJson("/Localization/JhIdentity")
                .AddVirtualJson("/Localization/JhAbpExtensions")//使用虚拟路径加载，并覆盖资源得键值对
                ;
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        configuration = context.Services.GetConfiguration();
        JhIdentityConsts.InitPassword = configuration["App:InitPassword"];
        ConfigureLocalizationOptions();

        context.Services.AddApiVersion();
        if (Convert.ToBoolean(configuration["AppSettings:SwaggerUI"]))
        {
            var Audience = configuration.GetValue<string>("AuthServer:ApiName");
            context.Services.AddJhAbpSwagger(configuration,
               new Dictionary<string, string>{
               {Audience, $"{Audience} API"}
               }, contractsType: typeof(JhIdentityApplicationContractsModule));
        }

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

            options.RedirectAllowedUrls.AddRange(configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray());
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

        //context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, IMailKitSmtpEmailSender>());
#if DEBUG
        //context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());//不发送电子邮件
#endif

        //context.Services.AddSameSiteCookiePolicy();//去除https
        //context.Services.AddAuthorizeFilter(configuration);//为所有请求添加验证

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

        //app.ApplicationServices.InitWorkflowDefinition(workflowHost =>
        //{
        //    //workflowHost.RegisterWorkflow<LeaveApplicationWorkflow, LeaveApplicationWorkflowDto>();
        //});

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseJwtTokenMiddleware();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAbpRequestLocalization();
        app.UseIdentityServer();
        app.UseAuthorization();
        if (Convert.ToBoolean(configuration["AppSettings:SwaggerUI"]))
        {
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.UseJhSwaggerUiConfig(configuration, app.ApplicationServices.GetRequiredService<Microsoft.Extensions.Options.IOptions<SwaggerApiOptions>>().Value);
            });
        }
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();

        await SeedData(context);
    }


    private async Task SeedData(ApplicationInitializationContext context)
    {
        using var scope = context.ServiceProvider.CreateScope();
        var data = scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>();
        var dataSeedContext = new DataSeedContext()
            .WithProperty("AdminEmail", "531003539@qq.com")
            .WithProperty("AdminPassword", "KimHo@123");

        await data.SeedAsync(dataSeedContext);
    }
}
