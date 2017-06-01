using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace API.Domain
{
    public interface IRepository
    {
        void Add<T>(T item) where T : class;
        T Single<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>>  predicate) where T : class;
        void Remove<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Remove<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
    }
}