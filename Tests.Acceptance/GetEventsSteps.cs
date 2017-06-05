using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using API.Domain;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using Xunit;

namespace Tests.Acceptance
{
    [Binding]
    public class GetEventsSteps
    {
        private readonly ScenarioContext _context;

        public GetEventsSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"the response contains the event")]
        public void ThenTheResponseBodyContainsTheEvent()
        {
            var response = _context.Get<HttpResponseMessage>();
            var expected = _context.Get<IEnumerable<Event>>().Single();
            var result = response.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<ExpandoObject[]>(result);
            dynamic actual = content.Single();

            Assert.Equal(expected.Id, actual.Id); 
            Assert.Equal(expected.Name, actual.Name);
            Assert.True(actual.OnSaleDate.Subtract(expected.OnSale).TotalSeconds < 1);
            Assert.True(actual.DoorOpenDate.Subtract(expected.DoorOpen).TotalSeconds < 1);
            Assert.True(actual.EventStartDate.Subtract(expected.Start).TotalSeconds < 1);
            Assert.True(actual.EventEndDate.Subtract(expected.End).TotalSeconds < 1);
        }

        [Then(@"the response should not contain any events")]
        public void ThenTheResponseShouldNotContainAnyEvents()
        {
            var response = _context.Get<HttpResponseMessage>();
            var result = response.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<ExpandoObject[]>(result);

            Assert.Equal(0, content.Length);
        }
    }
}