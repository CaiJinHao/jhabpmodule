using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitExtensionManager : DomainService
    {
        protected IOrganizationUnitExtensionRepository organizationUnitExtensionRepository => LazyServiceProvider.LazyGetRequiredService<IOrganizationUnitExtensionRepository>();

        public async Task<OrganizationUnitExtension> CreateAsync(OrganizationUnitExtension entity)
        {
            return await organizationUnitExtensionRepository.InsertAsync(entity);
        }

        public async Task UpdateAsync(Guid OrganizationUnitId, Guid? leaderId, int? leaderType)
        {
            var entity = await organizationUnitExtensionRepository.FindAsync(OrganizationUnitId);
            if (entity == null)
            {
                return;
            }
            entity.LeaderId = leaderId;
            entity.LeaderType = leaderType;
            await organizationUnitExtensionRepository.UpdateAsync(entity);
        }

        public async Task<OrganizationUnitExtension> GetAsync(Guid OrganizationUnitId)
        {
            return await organizationUnitExtensionRepository.FindAsync(OrganizationUnitId);
        }
    }
}
