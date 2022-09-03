using System.Threading.Tasks;

namespace Jh.Abp.JhIdentity
{
    public interface IEmailAppService
    {
        /// <summary>
        /// 发送邮箱验证码
        /// </summary>
        /// <returns></returns>
        Task SendEmailVerificationCodeAsync(SendEmailVerificationCodeInputDto input);
        /// <summary>
        /// 验证邮箱验证码
        /// </summary>
        /// <returns></returns>
        Task<bool> ValidateEmailVerificationCodeAsync(string key, string code);
    }
}
