using System.Data.Entity;
using API.Domain;

namespace API.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext() : base("EventTickets")
        {
            
        }

        public DbSet<Event> Events { get; set; }
    }
}