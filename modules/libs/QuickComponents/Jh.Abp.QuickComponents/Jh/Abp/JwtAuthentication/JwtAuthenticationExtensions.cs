using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.QuickComponents
{
    public static class JwtAuthenticationExtensions
    {
        /*
  "AuthServer": {
    "Authority": "https://localhost:6201/",
    "RequireHttpsMetadata": "false",
    //oidc
    "ClientId": "WebAppYourName_Web",
    "ClientSecret": "KimHo@666",
    "CookieExpireTimeSpanHours": 48,
    "Scope": "email openid profile role phone address WebAppYourName offline_access"
  },
         */
        /// <summary>
        /// 混合模式
        /// web 需要去除AbpAccountWebModule依赖
        /// 需要在AuthServer中添加oidc配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {
                    var Hours = configuration["AuthServer:CookieExpireTimeSpanHours"];
                    options.ExpireTimeSpan = TimeSpan.FromHours(Convert.ToInt32(Hours));
                })
                .AddAbpOpenIdConnect("oidc", options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                    options.ClientId = configuration["AuthServer:ClientId"];
                    options.ClientSecret = configuration["AuthServer:ClientSecret"];

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    var scopeStr= configuration["AuthServer:Scope"];
                    if (!string.IsNullOrWhiteSpace(scopeStr))
                    {
                        var scopes = scopeStr.Split(" ");
                        foreach (var item in scopes)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                options.Scope.Add(item);
                            }
                        }
                    }
                });
            return services;
        }

        /// <summary>
        /// 为所有请求添加权限验证，使用之后页面都会进行验证，需要配合appsettings.json AllowAnonymousRegex使用，过滤不需要权限得请求
        /// "AllowAnonymousRegex": "(^/[aA]bp)|(^/[aA]ccount)|(^/api/[aA]bp)|(^/)", //如果开启权限需要排除
        /// </summary>
        [Obsolete("不建议使用，请移步使用授权策略验证或者手动添加特性")]
        public static IServiceCollection AddAuthorizeFilter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                var policy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                         .RequireAuthenticatedUser()
                         .Build();
                options.Filters.Add(new JhAuthorizationFilter(policy, configuration));
            });
            return services;
        }
    }
}
