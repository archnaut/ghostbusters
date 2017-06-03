using System.Dynamic;
using System.Linq;
using System.Net.Http;
using API.Infrastructure;
using Chronic;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using Xunit;

namespace Tests.Acceptance
{
    [Binding]
    public class PurchaseTicketSteps
    {
        private readonly ScenarioContext _context;
        private readonly Parser _parser;

        public PurchaseTicketSteps(ScenarioContext context)
        {
            _context = context;
            _parser = new Parser();
        }


        [Then(@"I should receive the following receipt")]
        public void ThenIShouldReceiveTheFollowingReceipt(dynamic expected)
        {
            var expectedPurchaseDate = _parser.Parse(expected.PurchaseDate).ToTime().Date;
            var response = _context.Get<HttpResponseMessage>("OrderResponse");

            dynamic actual = JsonConvert.DeserializeObject<ExpandoObject>(response.Content.ReadAsStringAsync().Result);
            _context.Set(actual, "OrderResponseContent");

            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.True(actual.PurchaseDate.Date.Subtract(expectedPurchaseDate).TotalHours < 24);
            Assert.Equal(expected.AmountPaid, actual.AmountPaid);
        }

        [Then(@"receipt includes the following line items")]
        public void ThenReceiptIncludesTheFollowingLineItems(dynamic expected)
        {
            dynamic content = _context.Get<object>("OrderResponseContent");
            dynamic actual = Enumerable.First(content.Tickets);

            Assert.Equal(expected.TicketId, actual.TicketId);
        }

        [Then(@"the quantity available of ticket with ID (.*) should be (.*)")]
        public void ThenTheQuantityAvailableOfTicketWithIDShouldBe(int ticketId, int quantityAvailable)
        {
            using (var context = new DataContext())
            {
                var actual = context.Tickets.Single(x => x.Id == ticketId);

                Assert.Equal(quantityAvailable, actual.QuantityAvailable);
            }
        }
    }
}