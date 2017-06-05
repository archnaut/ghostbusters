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

namespace Tests.Unit.Controllers.GetTickets
{
    public class HappyPath
    {
        private const int EventId = 1;
        private readonly HttpResponseMessage _response;
        private readonly dynamic _content;
        private readonly Ticket _ticket01;
        private readonly Ticket _ticket02;

        public HappyPath()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var eventService = A.Fake<IEventService>();

            _ticket01 = new Ticket(1, 1, "General Admission", 10.00M, 500); 

            _ticket02 = new Ticket(2, 1, "VIP", 30.00M, 100);

            A.CallTo(() => eventService.GetTickets(EventId))
                .Returns( new[] { _ticket01, _ticket02 });

            var controller = new EventController(eventService) {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            _response = controller.GetTickets(EventId).ExecuteAsync(cancellationTokenSource.Token).Result;
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
        public void TicketCount()
        {
            Assert.Equal(2, _content.Length);
        }

        [Fact]
        public void Ticket01_Id()
        {
            Assert.Equal(_ticket01.Id, _content[0].Id);
        }

        [Fact]
        public void Ticket01_Name()
        {
            Assert.Equal(_ticket01.Name, _content[0].Name);
        }

        [Fact]
        public void Ticket01_Price()
        {
            Assert.Equal(_ticket01.Price, (decimal)_content[0].Price);
        }

        [Fact]
        public void Ticket02_Id()
        {
            Assert.Equal(_ticket02.Id, _content[1].Id);
        }

        [Fact]
        public void Ticket02_Name()
        {
            Assert.Equal(_ticket02.Name, _content[1].Name);
        }

        [Fact]
        public void Ticket02_Price()
        {
            Assert.Equal(_ticket02.Price, (decimal)_content[1].Price);
        }
    }
}