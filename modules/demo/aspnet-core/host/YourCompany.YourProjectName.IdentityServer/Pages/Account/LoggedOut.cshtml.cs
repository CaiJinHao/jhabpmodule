using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZhongChuLiangXiAnQuestion.Pages.Account
{
    public class LoggedOutModel : Volo.Abp.Account.Web.Pages.Account.LoggedOutModel
    {
        public override Task<IActionResult> OnGetAsync()
        {
            return Task.FromResult<IActionResult>(Redirect("~/Account/Login"));
        }
    }
}
