using Jh.Abp.Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Jh.Abp.AuditLogging
{
    public interface IAuditLoggingAppService
    {
        Task<ListResultDto<AuditLogDto>> GetEntitysAsync(AuditLoggingRetrieveInputDto inputDto, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<PagedResultDto<AuditLogDto>> GetListAsync(AuditLoggingRetrieveInputDto retrieveInputDto, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task DeleteAsync(AuditLoggingDeleteInputDto deleteInputDto, string methodStringType = ObjectMethodConsts.EqualsMethod, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(Guid[] keys, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<AuditLogDto> GetAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
