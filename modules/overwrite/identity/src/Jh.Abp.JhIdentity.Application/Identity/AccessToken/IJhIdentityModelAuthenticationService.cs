using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.IdentityModel;

namespace Jh.Abp.JhIdentity
{
    public interface IJhIdentityModelAuthenticationService: IIdentityModelAuthenticationService
    {
        Task<TokenResponse> GetAccessTokenResponseAsync(IdentityClientConfiguration configuration, string refreshToken = null);
    }
}
