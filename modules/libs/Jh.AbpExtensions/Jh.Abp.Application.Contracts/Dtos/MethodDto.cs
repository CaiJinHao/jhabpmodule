using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Jh.Abp.Application.Contracts
{
    /// <summary>
    /// 方法输入参数Dto
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MethodDto<TEntity>
    {
        /// <summary>
        /// 查询时Mongodb使用无效
        /// </summary>
        public Action<TEntity> CreateOrUpdateEntityAction;
        public Func<IQueryable<TEntity>, IQueryable<TEntity>> QueryAction;
        public Func<IQueryable<TEntity>, IQueryable<TEntity>> SelectAction;

        public string StringTypeQueryMethod { get; set; } = ObjectMethodConsts.ContainsMethod;
    }
}
