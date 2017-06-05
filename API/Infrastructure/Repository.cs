using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using API.Domain;
using EntityFramework.Extensions;

namespace API.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> All<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IEnumerable<TEntity> All<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> include) 
            where TEntity  : class
            where TProperty : class
        {
            return _context.Set<TEntity>().Include(include);
        }

        public T Single<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<TEntity> Find<TEntity, TProperty>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class
        {
            var query = _context.Set<TEntity>().Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        public void AddOrUpdate<T>(T item) where T : class
        {
            _context.Set<T>().AddOrUpdate(item);
        }

        public void Remove<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            _context.Set<T>()
                .Where(predicate)
                .Delete();
        }

        public void Remove<T>(T item) where T : class
        {
            _context.Set<T>().Remove(item);
        }

        public void Update<T>(T item) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AllInstances<T>() where T : class
        {
            return _context.Set<T>();
        }

        public int Update<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> map) where T : class
        {
            return _context.Set<T>()
                .Where(predicate)
                .Update(map);
        }

        public IUnitOfWork NewUnitOfWork()
        {
            return new UnitOfWork(_context);
        }

        private class UnitOfWork : IUnitOfWork
        {
            private readonly DbContext _context;
            private readonly DbContextTransaction _transaction;

            public UnitOfWork(DbContext context)
            {
                _context = context;
                _transaction = context.Database.BeginTransaction();
            }

            public void Commit()
            {
                _context.SaveChanges();
                _transaction.Commit();
            }

            public void Rollback()
            {
               _transaction.Rollback(); 
            }

            public void Dispose()
            {
                _transaction.Dispose();
            }
        }
    }
}