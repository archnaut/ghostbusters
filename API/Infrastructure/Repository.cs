using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public T Single<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Add<T>(T item) where T : class
        {
            _context.Set<T>().Add(item);
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

            public UnitOfWork(DbContext context)
            {
                _context = context;
            }

            public void Commit()
            {
                _context.SaveChanges();
            }

            public void Dispose()
            {
            }
        }
    }
}