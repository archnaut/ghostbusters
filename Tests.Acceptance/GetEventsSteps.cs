using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
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
        private HttpResponseMessage _response;

        [When(@"I make a  call to ""(.*)"" to get events")]
        public void WhenIMakeACallToToGetEvents(string url)
        {
            using (var client = new HttpClient())
                _response = client.GetAsync(url).Result;
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            Assert.Equal((HttpStatusCode) statusCode, _response.StatusCode);
        }

        [Then(@"the response body contains the event")]
        public void ThenTheResponseBodyContainsTheEvent()
        {
            var expected = ScenarioContext.Current.Get<IEnumerable<Event>>().Single();
            var result = _response.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<ExpandoObject[]>(result);
            dynamic actual = content.Single();

            Assert.Equal(expected.Id, actual.Id); 
            Assert.Equal(expected.Name, actual.Name);
            Assert.True(actual.OnSale.Subtract(expected.OnSale).TotalSeconds < 1);
            Assert.True(actual.DoorsOpen.Subtract(expected.DoorsOpen).TotalSeconds < 1);
            Assert.True(actual.Start.Subtract(expected.Start).TotalSeconds < 1);
            Assert.True(actual.End.Subtract(expected.End).TotalSeconds < 1);
        }
    }
}