using Jh.Abp.Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;

namespace Jh.Abp.JhAuditLogging
{
    public interface IAuditLoggingAppService
    {
        Task<ListResultDto<AuditLog>> GetEntitysAsync(AuditLoggingRetrieveInputDto inputDto, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<PagedResultDto<AuditLog>> GetListAsync(AuditLoggingRetrieveInputDto retrieveInputDto, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<AuditLog[]> DeleteAsync(AuditLoggingDeleteInputDto deleteInputDto, string methodStringType = ObjectMethodConsts.EqualsMethod, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<AuditLog[]> DeleteAsync(Guid[] keys, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<AuditLog> DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<AuditLog> GetAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
