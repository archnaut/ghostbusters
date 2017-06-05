using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Domain
{
    public interface IRepository
    {
        void AddOrUpdate<T>(T item) where T : class;
        IEnumerable<T> All<T>() where T : class;
        T Single<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>>  predicate) where T : class;

        IEnumerable<TEntity> Find<TEntity, TProperty>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class; 
        void Remove<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Remove<T>(T item) where T : class;
        void Update<T>(T item) where T : class;

        IUnitOfWork NewUnitOfWork();
    }
}