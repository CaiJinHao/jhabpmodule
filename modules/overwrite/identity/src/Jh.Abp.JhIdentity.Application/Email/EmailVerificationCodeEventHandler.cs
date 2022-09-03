using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus.Distributed;
using static Volo.Abp.UI.Navigation.DefaultMenuNames.Application;

namespace Jh.Abp.JhIdentity
{
    public class EmailVerificationCodeEventHandler : IDistributedEventHandler<EmailVerificationCodeEto>, ITransientDependency
    {
        public IEmailSender emailSender { get; set; }
        public IDistributedCache<string, string> codeDistributedCache { get; set; }

        protected virtual Task<string> GeneratorVerificationCodeAsync(int len = 6)
        {
            var mycode = new char[len];
            var random = new Random();
            for (int i = 0; i < len; i++)
            {
                mycode[i] = random.Next(0, 9).ToString().First();
            }
            return Task.FromResult(new string(mycode));
        }

        public virtual async Task HandleEventAsync(EmailVerificationCodeEto eventData)
        {
            var inputData = eventData;
            var code = await GeneratorVerificationCodeAsync(inputData.CodeLength);
            await codeDistributedCache.SetAsync(inputData.ToEmail, code, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            });
            await emailSender.SendAsync(inputData.ToEmail, "验证码", $"您的验证码是:【{code}】");
        }
    }
}
