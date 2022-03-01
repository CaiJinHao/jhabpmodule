using AutoMapper;
using IdentityModel.Client;
namespace Jh.Abp.JhIdentity
{
    public class AccessTokenProfile : Profile
    {
        public AccessTokenProfile()
        {
            //身份验证服务器响应
            CreateMap<TokenResponse, AccessTokenResponseDto>();
        }
    }
}
