using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.JhIdentity
{
    public interface IEmailAppService
    {
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        Task<string> GeneratorVerificationCodeAsync(int len = 6);
        /// <summary>
        /// 发送邮箱验证码
        /// </summary>
        /// <returns></returns>
        Task SendEmailVerificationCodeAsync(string email, string key, string code);
        /// <summary>
        /// 验证邮箱验证码
        /// </summary>
        /// <returns></returns>
        Task<bool> ValidateEmailVerificationCodeAsync(string key, string code);
    }
}
