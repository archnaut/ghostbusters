using System.Data.Common;
using System.Data.Entity.Infrastructure;
using Effort;

namespace Tests.Integration
{
    public class EffortProviderFactory : IDbConnectionFactory
    {
        private static DbConnection _connection;
        private static readonly object _lock = new object();

        public static void ResetDb()
        {
            lock (_lock)
            {
                _connection = null;
            }
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            lock (_lock)
            {
                if (_connection == null)
                {
                    _connection = DbConnectionFactory.CreateTransient();
                }

                return _connection;
            }
        }
    }
}