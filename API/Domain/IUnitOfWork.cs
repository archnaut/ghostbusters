using System;

namespace API.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}