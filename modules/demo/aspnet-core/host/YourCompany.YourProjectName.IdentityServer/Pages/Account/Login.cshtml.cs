using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;

namespace Jh.Abp.JhIdentity.Pages.Account
{
    public class LoginModel : Volo.Abp.Account.Web.Pages.Account.LoginModel
    {
        public IConfiguration Configuration { get; init; }
        public LoginModel(IAuthenticationSchemeProvider schemeProvider, IOptions<AbpAccountOptions> accountOptions, IOptions<IdentityOptions> identityOptions, IConfiguration configuration) : base(schemeProvider, accountOptions, identityOptions)
        {
        }

        protected override string GetAppHomeUrl()
        {
            return Configuration["App:AppHomeUrl"];
        }
    }
}
