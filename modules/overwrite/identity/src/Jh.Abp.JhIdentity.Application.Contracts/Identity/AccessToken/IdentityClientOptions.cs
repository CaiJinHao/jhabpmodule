using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.JhIdentity
{
    public class IdentityClientOptions
    {
        public string Authority { get; set; }
        public string Scope { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public bool RequireHttps { get; set; }
        public string Audience { get; set; }
    }
}
