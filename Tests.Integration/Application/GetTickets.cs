using System;
using System.Linq;
using API.Application;
using API.Domain;
using API.Infrastructure;
using Xunit;

namespace Tests.Integration.Application
{
    public class GetTickets
    {
        public GetTickets()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        }

        [Fact]
        public void CurrentEvent()
        {
            EffortProviderFactory.ResetDb();

            var today = DateTime.Now.Date;

            const int eventId = 1;
            const string eventName = "Current Event";


            var context = new DataContext();

            context.Events
                .Add(new Event(
                    eventId,
                    eventName,
                    today.AddDays(-30),
                    today.AddDays(4).AddHours(13),
                    today.AddDays(5).AddHours(14),
                    today.AddDays(5).AddHours(17)));

            context.Tickets.Add(new Ticket(eventId, "General Admission", 10.00M, 500));
            context.Tickets.Add(new Ticket(eventId, "VIP", 30.00M, 100));

            context.SaveChanges();

            var repository = new Repository(context);
            var eventService = new EventService(repository, new TaxService(0.975M), new ConcurencyExceptionHandler(repository));

            var actual = eventService.GetTickets(eventId);

            Assert.True(actual.All(x => x.Name.Equals("General Admission") || x.Name.Equals("VIP")));
        }

        [Fact]
        public void PastEvent()
        {
            EffortProviderFactory.ResetDb();

            var today = DateTime.Now.Date;

            const int eventId = 1;
            const string eventName = "Past Event";

            var context = new DataContext();

            context.Events.Add(new Event(
                eventId,
                eventName,
                today.AddDays(-35),
                today.AddDays(-5).AddHours(11),
                today.AddDays(-4).AddHours(9),
                today.AddDays(-4).AddHours(7)));

            context.Tickets.Add(new Ticket(eventId, "General Admission", 10.00M, 500));
            context.Tickets.Add(new Ticket(eventId, "VIP", 30.00M, 100));

            context.SaveChanges();

            var repository = new Repository(context);
            var eventService = new EventService(repository, new TaxService(0.975M), new ConcurencyExceptionHandler(repository));

            var actual = eventService.GetTickets(eventId);

            Assert.False(actual.Any());
        }
    }
}