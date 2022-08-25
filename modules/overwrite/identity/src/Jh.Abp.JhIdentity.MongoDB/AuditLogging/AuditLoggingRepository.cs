using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MongoDB;

namespace Jh.Abp.AuditLogging
{
    public class AuditLoggingRepository : MongoAuditLogRepository, IAuditLoggingRepository, ITransientDependency
    {
        public AuditLoggingRepository(IMongoDbContextProvider<IAuditLoggingMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<AuditLog[]> DeleteEntitysAsync(IQueryable<AuditLog> query, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entitys = query.ToArray();
            await base.DeleteManyAsync(entitys, autoSave, cancellationToken);
            return entitys;
        }

        public virtual async Task<AuditLog[]> DeleteListAsync(Expression<Func<AuditLog, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _dbSet = await GetMongoQueryableAsync();
            var entitys = _dbSet.Where(predicate).ToArray();
            await base.DeleteManyAsync(entitys, autoSave, cancellationToken);
            return entitys;
        }
    }
}
