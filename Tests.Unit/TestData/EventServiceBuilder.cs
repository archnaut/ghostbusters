using Application;
using FakeItEasy;

namespace Tests.Unit.TestData
{
    public class EventServiceBuilder
    {
        private readonly IEventService _eventService;

        public EventServiceBuilder()
        {
            _eventService = FakeItEasy.A.Fake<IEventService>();
        }

        public IEventService Build()
        {
            return _eventService;
        }
    }
}