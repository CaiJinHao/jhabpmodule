using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Jh.Abp.JhIdentity
{
    [DisableAuditing]
    public class ChangePasswordInputDto
    {
        [DisableAuditing]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
        public string CurrentPassword { get; set; }

        [Required]
        [DisableAuditing]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
        public string NewPassword { get; set; }
    }
}
