using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.EventBus.Distributed;

namespace Jh.Abp.JhIdentity.Pages.Account
{
    public class RegisterModel : Volo.Abp.Account.Web.Pages.Account.RegisterModel
    {
        public IEmailAppService EmailAppService { get; set; }
        [BindProperty]
        [Required]
        public string EmailCode { get; set; }
        public RegisterModel(IAccountAppService accountAppService) : base(accountAppService)
        {
        }

        public override async Task<IActionResult> OnPostAsync()
        {
            //验证邮箱验证码
            if (string.IsNullOrEmpty(Input.EmailAddress) && !await EmailAppService.ValidateEmailVerificationCodeAsync(Input.EmailAddress, EmailCode))
            {
                Alerts.Danger("邮箱验证码错误");
                return Page();
            }
            return await base.OnPostAsync();
        }
    }
}
