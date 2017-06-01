using System.Data.Entity;

namespace API.Infrastructure
{
    public class DataInitializer : DropCreateDatabaseAlways<DataContext>
    {
    }
}