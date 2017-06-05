using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using API.Application;
using API.Controllers;
using API.DTO;
using FakeItEasy;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Unit.Controllers.PurchaseTickets
{
    public class ExceptionThrown
    {
        private readonly HttpResponseMessage _response;
        private readonly dynamic _content;

        public ExceptionThrown()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var eventService = A.Fake<IEventService>();

            A.CallTo(() => eventService.Submit(A<OrderRequest>.Ignored))
                .Throws(()=> new Exception("Something Bad Happened!"));

            var controller = new EventController(eventService) {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var orderRequest = new OrderRequest
            {
                EventId = 1,
                FirstName = "Doc-Bob",
                LastName = "Haygreaser",
                CreditCardNumber = "0000-0000-0000-0000",
                SecurityCode = 123,
                ExpirationMonth = 1,
                ExpirationYear = 2018,
                Tickets = new[] { new OrderRequestItem(1, 1) }
            };

            _response = controller.PostOrder(orderRequest).ExecuteAsync(cancellationTokenSource.Token).Result;
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