using System;
using System.Linq;
using System.Linq.Expressions;

namespace PersonalSite.Interfaces
{
    public interface IReadOnlyRepository
    {
        IQueryable<TEntity> All<TEntity>();
        TEntity Query<TEntity>(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> FilterBy<TEntity>(Expression<Func<TEntity, bool>> expression);
    }
}