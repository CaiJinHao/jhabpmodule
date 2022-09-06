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
using Volo.Abp;
using JetBrains.Annotations;

namespace Jh.Abp.JhIdentity.Email
{
    [Dependency(ServiceLifetime.Singleton, ReplaceServices = true)]
    public class EmailAppService : JhIdentityAppService, IEmailAppService
    {
        protected IDistributedCache<string, string> codeDistributedCache => LazyServiceProvider.LazyGetRequiredService<IDistributedCache<string, string>>();
        protected IDistributedEventBus distributedEventBus => LazyServiceProvider.LazyGetRequiredService<IDistributedEventBus>();

        public virtual async Task SendEmailVerificationCodeAsync(SendEmailVerificationCodeInputDto input)
        {
            //判断是否还在有效期
            var emailCode = await codeDistributedCache.GetAsync(input.Email);
            if (emailCode == null)
            {
                await distributedEventBus.PublishAsync(new EmailVerificationCodeEto(input.Email, 6));
            }
            else
            {
                throw new UserFriendlyException($"邮箱验证码未过期，过期时间{EmailVerificationCodeEventHandler.ExpirationMinutes}分钟");
            }
        }

        public virtual async Task<bool> ValidateEmailVerificationCodeAsync([NotNull]string key, [NotNull] string code)
        {
            Check.NotNull(key,nameof(key));
            Check.NotNull(code, nameof(code));
            var emailCode = await codeDistributedCache.GetAsync(key);
            return code.Equals(emailCode);
        }
    }
}
