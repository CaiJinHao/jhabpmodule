using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.TextTemplating;

namespace Jh.Abp.JhIdentity.Providers
{
    public class EmailTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        //public override void Define(ITemplateDefinitionContext context)
        //{
        //    context.Add(
        //    new TemplateDefinition(
        //        AccountEmailTemplates.PasswordResetLink,
        //        displayName: LocalizableString.Create<AccountResource>($"TextTemplate:{AccountEmailTemplates.PasswordResetLink}"),
        //        layout: StandardEmailTemplates.Layout,
        //        localizationResource: typeof(AccountResource)
        //    ).WithVirtualFilePath("/Volo/Abp/Account/Emailing/Templates/PasswordResetLink.tpl", true)
        //    );
        //}
        public override void Define(ITemplateDefinitionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
