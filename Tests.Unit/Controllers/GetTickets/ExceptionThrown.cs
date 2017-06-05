using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using API.Application;
using API.Controllers;
using FakeItEasy;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Unit.Controllers.GetTickets
{
    public class ExceptionThrown
    {
        private readonly HttpResponseMessage _response;
        private readonly dynamic _content;

        public ExceptionThrown()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var presenter = A.Fake<IEventService>();

            A.CallTo(() => presenter.GetTickets(A<int>.Ignored))
                .Throws(()=> new Exception("Something Bad Happened!"));

            var controller = new EventController(presenter) {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            _response = controller.GetTickets(1).ExecuteAsync(cancellationTokenSource.Token).Result;
            var result = _response.Content.ReadAsStringAsync().Result;
            _content = JsonConvert.DeserializeObject<ExpandoObject>(result);
        }

        [Fact]
        public void StatusCode()
        {
            Assert.Equal(HttpStatusCode.InternalServerError, _response.StatusCode);
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
        public void ExceptionMessage()
        {
           Assert.Equal("An error has occurred.", _content.Message); 
        }
    }
}