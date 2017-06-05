using System;
using System.Linq;
using API.Application;
using API.Domain;
using API.Infrastructure;
using Xunit;

namespace Tests.Integration.Application
{
    public class GetEvents
    {
        public GetEvents()
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

            var currentEvent =
                new Event(
                    eventId,
                    eventName,
                    today.AddDays(-30),
                    today.AddDays(4).AddHours(13),
                    today.AddDays(5).AddHours(14),
                    today.AddDays(5).AddHours(17));

            var context = new DataContext();

            context.Events.Add(currentEvent);
            context.SaveChanges();

            var repository = new Repository(context);
            var eventService = new EventService(repository, new TaxService(0.975M), new ConcurencyExceptionHandler(repository));

            var actual = eventService.GetEvents();

            Assert.True(actual.Any(x => x.Name.Equals(eventName)));
        }

        [Fact]
        public void PastEvent()
        {
            EffortProviderFactory.ResetDb();

            var today = DateTime.Now.Date;

            const int eventId = 1;
            const string eventName = "Past Event";

            var currentEvent =
                new Event(
                    eventId,
                    eventName,
                    today.AddDays(-35),
                    today.AddDays(-5).AddHours(11),
                    today.AddDays(-4).AddHours(9),
                    today.AddDays(-4).AddHours(7));

            var context = new DataContext();

            context.Events.Add(currentEvent);
            context.SaveChanges();

            var repository = new Repository(context);
            var eventService = new EventService(repository, new TaxService(0.975M), new ConcurencyExceptionHandler(repository));

            var actual = eventService.GetEvents();

            Assert.False(actual.Any());
        }
    }
}