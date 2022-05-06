using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jh.Abp.JhIdentity.Localization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;

namespace Jh.Abp.JhIdentity.Pages.Account
{
    public class LoginModel : Volo.Abp.Account.Web.Pages.Account.LoginModel
    {
        protected IConfiguration Configuration { get; init; }
        protected IStringLocalizer<JhIdentityResource> JhIdentityStringLocalizer { get; init; }
        public LoginModel(IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions, 
            IOptions<IdentityOptions> identityOptions, 
            IConfiguration configuration,
            IStringLocalizer<JhIdentityResource> jhIdentityStringLocalizer) : base(schemeProvider, accountOptions, identityOptions)
        {
            JhIdentityStringLocalizer = jhIdentityStringLocalizer;
            Configuration = configuration;
        }

        protected override string GetAppHomeUrl()
        {
            return Configuration["App:AppHomeUrl"];
        }

        public string GetLocalizedString(string key)
        {
            return JhIdentityStringLocalizer[key];
        }
    }
}
