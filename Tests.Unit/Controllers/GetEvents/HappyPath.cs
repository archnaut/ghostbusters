using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using API.Application;
using API.Controllers;
using API.Domain;
using FakeItEasy;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Unit.Controllers.GetEvents
{
    public class HappyPath
    {
        private const string NameOfEvent = "Give Camp";
        private readonly HttpResponseMessage _response;
        private readonly dynamic _content;
        private readonly DateTime _onSale;
        private readonly DateTime _doorsOpen;
        private readonly DateTime _eventStart;
        private readonly DateTime _eventEnd;

        public HappyPath()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var today = DateTime.Now;
            _onSale = today.AddDays(-30);
            _doorsOpen = today.AddDays(4).AddHours(13);
            _eventStart = today.AddDays(5).AddHours(14);
            _eventEnd = today.AddDays(5).AddHours(17);

            
            var eventService = A.Fake<IEventService>();

            A.CallTo(() => eventService.GetEvents())
                .Returns(new[] {new Event(NameOfEvent, _onSale, _doorsOpen, _eventStart, _eventEnd)});

            var controller = new EventController(eventService);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            _response = controller.GetEvents().ExecuteAsync(cancellationTokenSource.Token).Result;
            _content = JsonConvert.DeserializeObject<ExpandoObject[]>(_response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public void StatusCode()
        {
            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }

        [Fact]
        public void ContentType()
        {
            Assert.Equal("application/json", _response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public void CharSet()
        {
            Assert.Equal("utf-8", _response.Content.Headers.ContentType.CharSet);
        }

        [Fact]
        public void EventCount()
        {
            Assert.Equal(1, _content.Length);
        }

        [Fact]
        public void EventName()
        {
            Assert.Equal(NameOfEvent, _content[0].Name);
        }

        [Fact]
        public void EventOnSaleDate()
        {
            Assert.Equal(_onSale, _content[0].OnSaleDate);
        }

        [Fact]
        public void EventDoorsOpen()
        {
            Assert.Equal(_doorsOpen, _content[0].DoorOpenDate);
        }

        [Fact]
        public void EventStart()
        {
            Assert.Equal(_eventStart, _content[0].EventStartDate);
        }

        [Fact]
        public void EventEnd()
        {
            Assert.Equal(_eventEnd, _content[0].EventEndDate);
        }
    }
}