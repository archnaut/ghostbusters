using System;
using System.Data.Entity.Migrations;
using API.Domain;
using API.Infrastructure;

namespace API.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<API.Infrastructure.DataContext>
    {
        private readonly Event[] _events;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "API.Infrastructure.DataContext";

            _events = CreateEvents();
        }

        protected override void Seed(DataContext context)
        {
            SeedEvent(context);
            SeedTickets(context);
        }

        private void SeedEvent(DataContext context)
        {
            context.Events.AddRange(_events);
            context.SaveChanges();
        }

        private void SeedTickets(DataContext context)
        {
            context.Tickets.AddRange(new[]
            {
                new Ticket(1, "General Admission", 10.00M, 500),
                new Ticket(1, "VIP", 30.00M, 100),
                new Ticket(2, "General Admission", 10.00M, 500),
                new Ticket(2, "VIP", 30.00M, 100),
                new Ticket(3, "General Admission", 10.00M, 0),
                new Ticket(3, "VIP", 30.00M, 100),
            }
                );

            context.SaveChanges();
        }

        private static Event[] CreateEvents()
        {
            return new[]
            {
                new Event
                    (
                    "Current Event",
                    DateTime.Parse("2017-05-05T00:00:00-05:00"),
                    DateTime.Parse("2017-06-08T13:00:00-05:00"),
                    DateTime.Parse("2017-06-09T14:00:00-05:00"),
                    DateTime.Parse("2017-06-09T17:00:00-05:00")
                    ),
                new Event
                    (
                    "Past Event",
                    DateTime.Parse("2017-04-05T00:00:00-05:00"),
                    DateTime.Parse("2017-05-08T13:00:00-05:00"),
                    DateTime.Parse("2017-05-09T14:00:00-05:00"),
                    DateTime.Parse("2017-05-09T17:00:00-05:00")
                    ),
                new Event
                    (
                    "Sold Out Event",
                    DateTime.Parse("2017-05-05T00:00:00-05:00"),
                    DateTime.Parse("2017-06-08T13:00:00-05:00"),
                    DateTime.Parse("2017-06-09T14:00:00-05:00"),
                    DateTime.Parse("2017-06-09T17:00:00-05:00")
                    )
            };
        }
    }
}
