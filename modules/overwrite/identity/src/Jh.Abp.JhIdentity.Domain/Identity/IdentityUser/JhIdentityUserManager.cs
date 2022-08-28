using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using System.Linq;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityUserManager : DomainService
    {
        protected IIdentityUserRepository IdentityUserRepository => LazyServiceProvider.LazyGetRequiredService<IIdentityUserRepository>();

        public async Task<string> GetIdentityUserNameAsync(Guid? userId)
        {
            if (userId == null)
            {
                return string.Empty;
            }
            var query = await IdentityUserRepository.GetQueryableAsync();
            return query.Where(a => a.Id == userId).Select(a => a.Name).FirstOrDefault();
        }
    }
}
