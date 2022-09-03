using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EventBus;

namespace Jh.Abp.JhIdentity
{
    [EventName("Jh.Abp.JhIdentity.EmailVerificationCode")]
    public class EmailVerificationCodeEto
    {
        public string ToEmail { get; set; }
        public short CodeLength { get; set; }

        public EmailVerificationCodeEto() { }
        public EmailVerificationCodeEto(string toEmail,short codeLength)
        {
            ToEmail = toEmail;
            CodeLength = codeLength;
        }
    }
}
