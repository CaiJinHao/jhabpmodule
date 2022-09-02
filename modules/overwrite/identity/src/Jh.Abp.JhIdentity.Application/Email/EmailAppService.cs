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

namespace Jh.Abp.JhIdentity.Email
{
    [Dependency(ServiceLifetime.Singleton, ReplaceServices = true)]
    public class EmailAppService : JhIdentityAppService, IEmailAppService
    {
        protected IEmailSender emailSender => LazyServiceProvider.LazyGetRequiredService<IEmailSender>();
        protected IDistributedCache<string, string> codeDistributedCache => LazyServiceProvider.LazyGetRequiredService<IDistributedCache<string, string>>();

        public virtual Task<string> GeneratorVerificationCodeAsync(int len = 6)
        {
            var mycode = new char[len];
            var random = new Random();
            for (int i = 0; i < len; i++)
            {
                mycode[i] = random.Next(0, 9).ToString().First();
            }
            return Task.FromResult(new string(mycode));
        }

        public virtual async Task SendEmailVerificationCodeAsync(string email, string key, string code)
        {
            await codeDistributedCache.SetAsync(key, code, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            });
            await emailSender.SendAsync(email, "验证码", $"您的验证码是:【{code}】");
        }

        public virtual async Task<bool> ValidateEmailVerificationCodeAsync(string key, string code)
        {
            var emailCode = await codeDistributedCache.GetAsync(key);
            return code.Equals(emailCode);
        }
    }
}
