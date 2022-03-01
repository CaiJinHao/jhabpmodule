using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Threading;

namespace Jh.Abp.JhIdentity
{
    public class JhOrganizationUnitManager : OrganizationUnitManager
    {
        public JhOrganizationUnitManager(Volo.Abp.Identity.IOrganizationUnitRepository organizationUnitRepository, IStringLocalizer<IdentityResource> localizer, Volo.Abp.Identity.IIdentityRoleRepository identityRoleRepository, ICancellationTokenProvider cancellationTokenProvider) : base(organizationUnitRepository, localizer, identityRoleRepository, cancellationTokenProvider)
        {
        }

        public virtual async Task RecoverAsync(Guid id, bool isDeleted = false)
        {
            foreach (var item in await GetParentsAsync(id))
            {
                item.IsDeleted = isDeleted;
            }
        }
        protected virtual async Task<List<OrganizationUnit>> GetParentsAsync(Guid? id)
        {
            var data = new List<OrganizationUnit>();
            async Task GetParent(Guid parenttid)
            {
                var root = await OrganizationUnitRepository.GetAsync(parenttid);
                data.Add(root);
                if (root.ParentId.HasValue)
                {
                    await GetParent((Guid)root.ParentId);
                }
            }
            if (id.HasValue)
            {
                await GetParent((Guid)id);
            }
            return data;
        }
    }
}
