using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.QuickComponents.Swagger
{
    public static partial class SwaggerExtensions
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services, Action<ApiVersioningOptions> setupAction = null)
        {
            services.AddAbpApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                //是否在没有填写版本号的情况下使用默认版本
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                //options.ApiVersionReader = new UrlSegmentApiVersionReader();
                //options.ApiVersionReader = new HeaderApiVersionReader("api-version"); //Supports header too
                //options.ApiVersionReader = new MediaTypeApiVersionReader(); //Supports accept header too

                setupAction?.Invoke(options);
            });

            return services;
        }

        public static IServiceCollection AddJhAbpSwagger(this IServiceCollection services, IConfiguration configuration
            , Dictionary<string, string> scopes, Action<SwaggerGenOptions> setupAction = null, params Type[] contractsType)
        {
            services.AddAbpSwaggerGenWithOAuth(
                configuration["AuthServer:Authority"], scopes,
                options =>
                {
                    var swaggerApi = services.GetRequiredService<IOptions<SwaggerApiOptions>>().Value;
                    foreach (var item in swaggerApi.OpenApiInfos)
                    {
                        options.SwaggerDoc(item.GroupName,
                          new OpenApiInfo
                          {
                              Title = item?.Title ?? item.GroupName,
                              Version = item.Version.ToString(),
                              Description = item?.Description ?? item.GroupName
                          });
                    }

                    //必须保证RelativePath只被替换了一次
                    var GetRelativePath = (string RelativePath, string groupName) => RelativePath.Replace("v{apiVersion}", groupName);

                    options.DocInclusionPredicate((groupName, apiDesc) =>
                    {
                        var versionGroupName = groupName.ToLower();
                        //同一个版本的放在同一个文档
                        if (apiDesc.ActionDescriptor is Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor actionDescrptor)
                        {
                            var mapToApiVersionAttrs = actionDescrptor.MethodInfo.CustomAttributes.Where(a => a.AttributeType == typeof(MapToApiVersionAttribute)).ToList();
                            if (mapToApiVersionAttrs.Any())
                            {
                                return mapToApiVersionAttrs.Any(a => {
                                    var versionArg = a.ConstructorArguments.FirstOrDefault();
                                    var version = Convert.ToDouble(versionArg.Value.ToString());
                                    if (versionGroupName.Equals($"v{version}"))
                                    {
                                        apiDesc.RelativePath = GetRelativePath(apiDesc.RelativePath, versionGroupName);
                                        return true;
                                    }
                                    return false;
                                });
                            }
                        }
                        if (versionGroupName == "v1")
                        {
                            apiDesc.RelativePath = GetRelativePath(apiDesc.RelativePath, versionGroupName);
                            return true;
                        }
                        return false;
                    });
                    options.CustomSchemaIds(type => type.FullName);

                    //Swagger添加授权验证服务
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "授权Token：Bearer Token",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });

                    //options.SchemaFilter<SwaggerSchemaFilter>();//Schemax过滤器、修改器
                    //options.ParameterFilter<SwaggerSchemaFilter>();//Parameter过滤器、修改器
                    //options.RequestBodyFilter<>();//请求Body过滤器、修改器
                    //options.OperationFilter<>();//操作过滤器、修改器
                    //options.DocumentFilter<>();//文档过滤器、修改器

                    foreach (var item in contractsType)
                    {
                        var embeddedFileProvider = new EmbeddedFileProvider(item.Assembly, item.Namespace);//文件必须是嵌入得资源
                        var files = embeddedFileProvider.GetDirectoryContents(string.Empty).Where(a => a.Name.EndsWith(".xml"));
                        foreach (var file in files)
                        {
                            var content = file.ReadAsString();
                            options.IncludeXmlComments(() => {
                                return new System.Xml.XPath.XPathDocument(new StringReader(content));
                            }, true);//为操作、参数和模式注入基于XML注释文件的友好描述
                        }
                    }

                    options.IgnoreObsoleteActions();//忽略任何由ObsoleteAttribute修饰的操作
                    options.DescribeAllParametersInCamelCase();//描述所有参数，不管它们在代码中是如何出现的，都使用驼峰形式
                    //options.ResolveConflictingActions((apiDescriptionList) =>
                    //{
                    //    //合并具有冲突的HTTP方法和路径的操作(Swagger 2.0必须是唯一的)
                    //    return apiDescriptionList.First();
                    //});
                    //属性
                    options.IgnoreObsoleteProperties();//忽略任何用ObsoleteAttribute装饰的属性
                    options.UseAllOfForInheritance();//启用复合模式生成,合并基类的属性
                    options.UseAllOfToExtendReferenceSchemas();//扩展引用模式(使用allOf构造)，以便上下文元数据可以应用于所有参数和属性模式
                    options.SupportNonNullableReferenceTypes();//启用对非空引用类型的检测，在模式属性上相应地设置空标志

                    setupAction?.Invoke(options);
                });
            return services;
        }

        public static void UseJhSwaggerUiConfig(this Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions options, IConfiguration configuration, SwaggerApiOptions swaggerApi)
        {
            foreach (var item in swaggerApi.OpenApiInfos)
            {
                options.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName);
            }

            options.DocumentTitle = configuration["SwaggerApi:DocumentTitle"];
            options.RoutePrefix = configuration["SwaggerApi:RoutePrefix"];

            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            var Audience = configuration.GetValue<string>("AuthServer:Audience");
            options.OAuthScopes(Audience);

            // Display
            options.DefaultModelExpandDepth(3);//在模型-示例部分，模型的默认扩展深度
            options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);//模型得显示方式
            options.DefaultModelsExpandDepth(-1);//模型的默认扩展深度(设置为-1完全隐藏模型)
            options.DisplayOperationId();//控制操作列表中operationId的显示
            options.DisplayRequestDuration();//请求的持续时间(以毫秒为单位)的显示
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);//文档得展开方式
            options.EnableDeepLinking();//支持标签和操作的深度链接
            options.EnableFilter();//顶部栏将显示一个编辑框
            options.ShowExtensions();//字段和值的显示
            options.EnableValidator();//启用内置验证器
                                      //options.ShowCommonExtensions();//字段和参数值的显示
                                      //options.EnableTryItOutByDefault();//默认情况下启用“尝试”部分。

            //添加自定义css和js
            //向index.html页面注入额外的CSS样式表
            //options.InjectStylesheet("/ext/custom-stylesheet.css");
            //options.InjectJavascript("/ext/custom-javascript.js");
        }
    }
}
