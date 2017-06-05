using System;
using System.Linq;
using System.Linq.Expressions;
using API.Application;
using API.Domain;
using API.Infrastructure;
using FakeItEasy;
using Xunit;

namespace Tests.Unit.Application
{
    public class GetEvents
    {
        [Fact]
        public void CurrentEvent()
        {
            var today = DateTime.Now.Date;

            const int eventId = 1;
            const string eventName = "Current Event";

            var currentEvent = new[] {
               new Event(
                   eventId,
                   eventName,
                   today.AddDays(-30),
                   today.AddDays(4).AddHours(13),
                   today.AddDays(5).AddHours(14),
                   today.AddDays(5).AddHours(17))
            };

            var repository = A.Fake<IRepository>();
            A.CallTo(() => repository.Find(A<Expression<Func<Event, bool>>>.Ignored))
                .Returns(currentEvent);

            var concurencyExceptionHandler = A.Fake<IConcurencyExceptionHandler>();
            var taxService = A.Fake<ITaxService>();

            var eventService = new EventService(repository, taxService, concurencyExceptionHandler);

            var actual = eventService.GetEvents();

            Assert.True(actual.Any(x => x.Name.Equals(eventName)));
        }
    }
}