using System.Net.Http;
using System.Web.Http;
using Application;
using API.Controllers;

namespace Tests.Unit.TestData
{
    public class EventControllerBuilder
    {
        private HttpConfiguration _configuration;
        private IEventService _eventService;
        private HttpRequestMessage _request;


        public EventControllerBuilder WithEventService(IEventService service)
        {
            _eventService = service;

            return this;
        }

        public EventControllerBuilder WithConfiguration(HttpConfiguration configuration)
        {
            _configuration = configuration;

            return this;
        }

        public EventControllerBuilder WithRequest(HttpRequestMessage request)
        {
            _request = request;

            return this;
        }

        public EventController Build()
        {
            return new EventController(_eventService) {
                Configuration = _configuration,
                Request = _request
            };
        }
    }
}