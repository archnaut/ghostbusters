﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Domain;
using API.Infrastructure;
using Chronic;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using Xunit;

namespace Tests.Acceptance
{
    [Binding]
    public class GetEventsSteps
    {
        private readonly Parser _parser;
        private Event _expected;
        private HttpResponseMessage _response;

        public GetEventsSteps()
        {
            _parser = new Parser();
        }

        [Given(@"upcoming event")]
        public void GivenUpcomingEvent(Table table)
        {
            var row = table.Rows[0];

            var onSaleDate = _parser.Parse(row["On Sale Date"]);
            var doorsOpenDate = _parser.Parse(row["Doors Open Date"]);
            var startDate = _parser.Parse(row["Event Start Date"]);
            var endDate = _parser.Parse(row["Event End Date"]);

            _expected = new Event {
                Id = int.Parse(row["ID"]),
                Name = row["Name"],
                OnSaleDate = onSaleDate.ToTime(),
                DoorsOpenDate = doorsOpenDate.ToTime(),
                StarteDate = startDate.ToTime(),
                EndDate = endDate.ToTime()
            };

            using(var context = new DataContext())
            {
                context.Events.Add(_expected);
                context.SaveChanges();
            }
        }

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
        public void ThenTheResponseStatusCodeIs(int p0)
        {
            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }
        
        [Then(@"the response body contains")]
        public void ThenTheResponseBodyContains()
        {
            var actual = JsonConvert.DeserializeObject<Event[]>(_response.Content.ReadAsStringAsync().Result).Single();
            
            Assert.Equal(_expected.Id, actual.Id);
            Assert.Equal(_expected.Name, actual.Name);
            Assert.Equal(_expected.OnSaleDate.ToString("s"), actual.OnSaleDate.ToString("s"));
            Assert.Equal(_expected.StarteDate.ToString("s"), actual.StarteDate.ToString("s"));
            Assert.Equal(_expected.EndDate.ToString("s"), actual.EndDate.ToString("s"));
        }

        [BeforeScenario]
        public void Setup()
        {
            using (var context = new DataContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Events");
            }
        }
    }
}
