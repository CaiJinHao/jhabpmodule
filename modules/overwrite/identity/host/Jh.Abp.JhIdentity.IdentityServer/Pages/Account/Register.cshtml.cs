using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Jh.Abp.JhIdentity.Pages.Account
{
    public class RegisterModel : Volo.Abp.Account.Web.Pages.Account.RegisterModel
    {
        public IEmailAppService EmailAppService { get; set; }
        [BindProperty]
        [Required]
        [RegularExpression(@"\d{6}",ErrorMessage = "验证码是6位数字组成的")]
        public string EmailCode { get; set; }
        public RegisterModel(IAccountAppService accountAppService) : base(accountAppService)
        {
        }

        public override async Task<IActionResult> OnPostAsync()
        {
            //TODO:多语言修改
            //验证邮箱验证码
            if (!await EmailAppService.ValidateEmailVerificationCodeAsync(Input.EmailAddress, EmailCode))
            {
                Alerts.Danger("邮箱验证码错误");
                return Page();
            }
            return await base.OnPostAsync();
        }
    }
}
