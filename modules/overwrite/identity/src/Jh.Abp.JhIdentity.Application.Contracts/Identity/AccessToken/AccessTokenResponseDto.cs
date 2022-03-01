using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 访问令牌服务响应
    /// </summary>
    public class AccessTokenResponseDto
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
    }
}
