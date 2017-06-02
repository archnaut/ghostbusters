using System.Data.Entity;
using API.Domain;
using Ninject;

namespace API.Infrastructure
{
    public class DataContext : DbContext
    {
        [Inject]
        public DataContext() : base("EventTickets") { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}