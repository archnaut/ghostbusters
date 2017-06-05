using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using API.Domain;

namespace API.Infrastructure
{
    internal class ConcurencyExceptionHandler : IConcurencyExceptionHandler
    {
        private readonly int _maxRetry;
        private readonly IRepository _repository;

        public ConcurencyExceptionHandler(IRepository repository, int maxRetry = 5)
        {
            _repository = repository;
            _maxRetry = maxRetry;
        }

        public T Commit<T>(Func<T> unitOfWork)
        {
            var results = default(T);
            var attempts = 0;
            bool fail;

            do
            {
                attempts++;                    
                fail = false;
                using (var uow = _repository.NewUnitOfWork())
                {
                    try
                    {
                        results = unitOfWork();
                        uow.Commit();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (attempts == _maxRetry)
                        {
                            uow.Rollback();
                            throw;
                        }

                        fail = true;
                        ex.Entries.Single().Reload();
                    }
                    catch (Exception)
                    {
                        uow.Rollback();
                        throw;
                    }
                }
            } while (fail);

            return results;
        }
    }
}