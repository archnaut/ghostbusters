using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using Xunit;

namespace Tests.Acceptance
{
    [Binding]
    public class Client
    {
        private readonly ScenarioContext _context;

        public Client(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"I make a call to ""(.*)""")]
        public void WhenIMakeACallToToGetEvents(string url)
        {
            using (var client = new HttpClient())
                _context.Set(client.GetAsync(url).Result);
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            var response = _context.Get<HttpResponseMessage>();
            Assert.Equal((HttpStatusCode)statusCode, response.StatusCode);
        }

        [Then(@"the content type is ""(.*)"" and charset ""(.*)""")]
        public void ThenTheContentTypeIs(string contentType, string charSet)
        {
            var response = _context.Get<HttpResponseMessage>();

            Assert.Equal(contentType, response.Content.Headers.ContentType.MediaType);
            Assert.Equal(charSet, response.Content.Headers.ContentType.CharSet);
        }

        [When(@"I submit the following order to ""(.*)""")]
        public void WhenISubmitTheFollowingOrderTo(string url, dynamic order)
        {
            _context.Set(new {Url = url, Order = order}, "OrderRequest");
        }

        [When(@"the order includes the following line items")]
        public void WhenTheOrderIncludesTheFollowingLineItems(dynamic orderItems)
        {
            dynamic request = _context.Get<object>("OrderRequest");
            request.Order.Tickets = new[] { orderItems };

            var content = new StringContent(
                JsonConvert.SerializeObject(request.Order),
                Encoding.UTF8,
                "application/json");

            using (var client = new HttpClient())
                _context.Set(client.PostAsync(request.Url, content).Result);
        }
    }
}