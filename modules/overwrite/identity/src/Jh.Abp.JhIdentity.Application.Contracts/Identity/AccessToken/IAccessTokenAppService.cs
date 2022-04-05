using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Jh.Abp.JhIdentity
{
    public interface IAccessTokenAppService : IApplicationService
    {
        /// <summary>
        /// 加验证码是为了频繁访问数据库验证问题，直接先验证内存，验证内存通过之后验证数据库
        /// </summary>
        /// <returns>IdentityServer响应结果</returns>
        Task<AccessTokenResponseDto> GetAccessTokenAsync(AccessTokenRequestDto requestDto);

        /// <summary>
        /// 提供给没有账号密码又需要授权的接入方使用
        /// </summary>
        /// <returns></returns>
        Task<AccessTokenResponseDto> GetAccessTokenAsync(string Audience);

        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        Task<AccessTokenResponseDto> GetRefreshAccessTokenAsync(AccessTokenRefreshDto accessTokenRefreshDto);
    }
}
