using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Linq;
using Jh.Abp.JhIdentity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.AuditLogging
{
    [DisableAuditing]
    public class AuditLoggingAppService : JhIdentityAppService, IAuditLoggingAppService, ITransientDependency
    {
        public IAuditLoggingRepository auditLogsRepository => LazyServiceProvider.LazyGetRequiredService<IAuditLoggingRepository>();
        public virtual async Task<AuditLog[]> DeleteAsync(AuditLoggingDeleteInputDto deleteInputDto, string methodStringType = ObjectMethodConsts.EqualsMethod, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var lambda = LinqExpression.ConvetToExpression<AuditLoggingDeleteInputDto, AuditLog>(deleteInputDto, methodStringType);
            var query = (await auditLogsRepository.GetQueryableAsync()).AsNoTracking().Where(lambda);
            return await auditLogsRepository.DeleteEntitysAsync(query, autoSave, cancellationToken);
        }

        public virtual async Task<AuditLog> GetAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await auditLogsRepository.GetAsync(id, includeDetails, cancellationToken);
        }

        public virtual async Task<PagedResultDto<AuditLog>> GetListAsync(AuditLoggingRetrieveInputDto retrieveInputDto, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var datas = await auditLogsRepository.GetListAsync(
                sorting: retrieveInputDto.Sorting,
                maxResultCount: retrieveInputDto.MaxResultCount,
                skipCount: retrieveInputDto.SkipCount,
                startTime: retrieveInputDto.StartTime,
                endTime: retrieveInputDto.EndTime,
                httpMethod: retrieveInputDto.HttpMethod,
                url: retrieveInputDto.Url,
                userId: retrieveInputDto.UserId,
                userName: retrieveInputDto.UserName,
                applicationName: retrieveInputDto.ApplicationName,
                correlationId: retrieveInputDto.CorrelationId,
                clientIpAddress: retrieveInputDto.ClientIpAddress,
                maxExecutionDuration: retrieveInputDto.MaxExecutionDuration,
                minExecutionDuration: retrieveInputDto.MinExecutionDuration,
                hasException: retrieveInputDto.HasException,
                httpStatusCode: retrieveInputDto.HttpStatusCode,
                includeDetails: includeDetails,
                cancellationToken: cancellationToken);
            var totalCount = await auditLogsRepository.GetCountAsync(
                startTime: retrieveInputDto.StartTime,
                endTime: retrieveInputDto.EndTime,
                httpMethod: retrieveInputDto.HttpMethod,
                url: retrieveInputDto.Url,
                userId: retrieveInputDto.UserId,
                userName: retrieveInputDto.UserName,
                applicationName: retrieveInputDto.ApplicationName,
                correlationId: retrieveInputDto.CorrelationId,
                maxExecutionDuration: retrieveInputDto.MaxExecutionDuration,
                minExecutionDuration: retrieveInputDto.MinExecutionDuration,
                hasException: retrieveInputDto.HasException,
                httpStatusCode: retrieveInputDto.HttpStatusCode,
                cancellationToken: cancellationToken);

            return new PagedResultDto<AuditLog>()
            {
                Items = datas,
                TotalCount = totalCount
            };
        }

        public virtual async Task<AuditLog[]> DeleteAsync(Guid[] keys, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await auditLogsRepository.DeleteListAsync(a => keys.Contains(a.Id), autoSave, cancellationToken);
        }

        public virtual async Task<AuditLog> DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return (await auditLogsRepository.DeleteListAsync(a => a.Id.Equals(id), autoSave, cancellationToken)).FirstOrDefault();
        }

        public virtual async Task<ListResultDto<AuditLog>> GetEntitysAsync(AuditLoggingRetrieveInputDto retrieveInputDto, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var datas = await auditLogsRepository.GetListAsync(
                sorting: retrieveInputDto.Sorting,
                maxResultCount: retrieveInputDto.MaxResultCount,
                skipCount: retrieveInputDto.SkipCount,
                startTime: retrieveInputDto.StartTime,
                endTime: retrieveInputDto.EndTime,
                httpMethod: retrieveInputDto.HttpMethod,
                url: retrieveInputDto.Url,
                userId: retrieveInputDto.UserId,
                userName: retrieveInputDto.UserName,
                applicationName: retrieveInputDto.ApplicationName,
                correlationId: retrieveInputDto.CorrelationId,
                maxExecutionDuration: retrieveInputDto.MaxExecutionDuration,
                minExecutionDuration: retrieveInputDto.MinExecutionDuration,
                hasException: retrieveInputDto.HasException,
                httpStatusCode: retrieveInputDto.HttpStatusCode,
                includeDetails: includeDetails,
                cancellationToken: cancellationToken);
            return new ListResultDto<AuditLog>()
            {
                Items = datas
            };
        }
    }
}