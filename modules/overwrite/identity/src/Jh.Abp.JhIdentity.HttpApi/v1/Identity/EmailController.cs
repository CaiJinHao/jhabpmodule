using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace Jh.Abp.JhIdentity.v1.Identity
{
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class EmailController : JhIdentityController, IEmailAppService
    {
        protected IEmailAppService emailAppService => LazyServiceProvider.LazyGetRequiredService<IEmailAppService>();

        [Microsoft.AspNetCore.Mvc.Route("SendEmailCode")]
        [HttpPost]
        public async Task SendEmailVerificationCodeAsync(SendEmailVerificationCodeInputDto input)
        {
            await emailAppService.SendEmailVerificationCodeAsync(input);
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.Route("ValidateEmailCode")]
        [HttpPost]
        public Task<bool> ValidateEmailVerificationCodeAsync(string key, string code)
        {
            throw new NotImplementedException();
        }
    }
}
