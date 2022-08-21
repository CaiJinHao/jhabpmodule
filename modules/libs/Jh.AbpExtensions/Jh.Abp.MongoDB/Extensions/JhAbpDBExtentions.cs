using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp
{
    public static class JhAbpMongoDBExtentions
    {
        public static IQueryable<TEntity> AsNoTracking<TEntity>(this IQueryable<TEntity> query, bool isTracking) where TEntity : class
        {
            return query;
        }
    }
}
