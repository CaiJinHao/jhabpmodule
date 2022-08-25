using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Account;

namespace Jh.Abp.JhIdentity.Pages.Account
{
    public class RegisterModel : Volo.Abp.Account.Web.Pages.Account.RegisterModel
    {
        public RegisterModel(IAccountAppService accountAppService) : base(accountAppService)
        {
        }
    }
}
