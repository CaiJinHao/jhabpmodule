using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Emailing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MailKit;
using Volo.Abp.EventBus.Distributed;
using Microsoft.CodeAnalysis.Emit;

namespace Jh.Abp.JhIdentity.Email
{
    [Dependency(ServiceLifetime.Singleton, ReplaceServices = true)]
    public class EmailAppService : JhIdentityAppService, IEmailAppService
    {
        protected IDistributedCache<string, string> codeDistributedCache => LazyServiceProvider.LazyGetRequiredService<IDistributedCache<string, string>>();
        protected IDistributedEventBus distributedEventBus => LazyServiceProvider.LazyGetRequiredService<IDistributedEventBus>();

        public virtual async Task SendEmailVerificationCodeAsync(SendEmailVerificationCodeInputDto input)
        {
            await distributedEventBus.PublishAsync(new EmailVerificationCodeEto(input.Email, 6));
        }

        public virtual async Task<bool> ValidateEmailVerificationCodeAsync(string key, string code)
        {
            var emailCode = await codeDistributedCache.GetAsync(key);
            return code.Equals(emailCode);
        }
    }
}
