using System;
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

        [When(@"I make a  call to")]
        public void WhenIMakeACallTo(Table table)
        {
            var row = table.Rows[0];
            var uri = new Uri($"http://localhost:{row["Port"]}/{row["Path"]}");

            using (var client = new HttpClient())
            {
                _response = client.GetAsync(uri).Result;
            }
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            Assert.Equal((HttpStatusCode) statusCode, _response.StatusCode);
        }

        [Then(@"the response body contains the event")]
        public void ThenTheResponseBodyContainsTheEvent(Table table)
        {
            //var mapper = new EventMapper();
            //var expected = mapper.Map(table.Rows.Single());
            //var actual = JsonConvert.DeserializeObject<Event[]>(_response.Content.ReadAsStringAsync().Result).Single();

            //Assert.Equal(expected["Id"], actual.Id.ToString());
            //Assert.Equal(expected["Name"], actual.Name);
            //Assert.Equal(expected["OnSale"], actual.OnSale.ToString("s"));
            //Assert.Equal(expected["Start"], actual.Start.ToString("s"));
            //Assert.Equal(expected["End"], actual.End.ToString("s"));
        }
    }
}