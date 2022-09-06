using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jh.Abp.JhIdentity
{
    public class SendEmailVerificationCodeInputDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
