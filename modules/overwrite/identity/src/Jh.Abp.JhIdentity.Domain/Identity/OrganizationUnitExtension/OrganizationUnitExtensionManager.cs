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
        protected IRepository<OrganizationUnitExtension, Guid> crudRepository => LazyServiceProvider.LazyGetRequiredService<IRepository<OrganizationUnitExtension, Guid>>();

        public async Task<OrganizationUnitExtension> CreateAsync(OrganizationUnitExtension entity)
        {
            return await crudRepository.InsertAsync(entity);
        }

        public async Task UpdateAsync(Guid OrganizationUnitId, Guid? leaderId, int? leaderType)
        {
            var entity = await crudRepository.FindAsync(OrganizationUnitId);
            if (entity == null)
            {
                return;
            }
            entity.LeaderId = leaderId;
            entity.LeaderType = leaderType;
            await crudRepository.UpdateAsync(entity);
        }

        public async Task<OrganizationUnitExtension> GetAsync(Guid OrganizationUnitId)
        {
            return await crudRepository.FindAsync(OrganizationUnitId);
        }
    }
}
