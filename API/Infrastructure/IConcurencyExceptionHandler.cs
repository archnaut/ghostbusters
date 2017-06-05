using System;

namespace API.Infrastructure
{
    public interface IConcurencyExceptionHandler
    {
        TResults Commit<TResults>(Func<TResults> unitOfWork);
    }
}