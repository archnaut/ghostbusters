using System.Dynamic;
using System.Linq;
using System.Net.Http;
using API.Domain;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tests.Acceptance.Builders;
using Tests.Acceptance.Model;
using Xunit;

namespace Tests.Acceptance
{
    [Binding]
    public class GetTicketsSteps
    {
        private readonly ScenarioContext _context;

        public GetTicketsSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"the response should include the following tickets")]
        public void ThenTheResponseShouldIncludeTheFollowingTickets(Table table)
        {
            var response = _context.Get<HttpResponseMessage>();
            var result = response.Content.ReadAsStringAsync().Result;

            var actual = JsonConvert.DeserializeObject<TicketBuilder[]>(result)
                .Select(x => x.Build())
                .ToList();

            var expected = table.CreateSet<TicketBuilder>()
                .Select(x => x.Build())
                .ToList();

            Assert.Equal(expected[0].Id, actual[0].Id);
            Assert.Equal(expected[0].Name, actual[0].Name);
            Assert.Equal(expected[0].Price, actual[0].Price);

            Assert.Equal(expected[1].Id, actual[1].Id);
            Assert.Equal(expected[1].Name, actual[1].Name);
            Assert.Equal(expected[1].Price, actual[1].Price);
        }
    }
}
