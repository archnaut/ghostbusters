﻿using System.Collections.Generic;
using System.Linq;
using API.Domain;
using API.Infrastructure;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tests.Acceptance.Model;

namespace Tests.Acceptance
{
    [Binding]
    public class TestData
    {
        [Given(@"the following event\(s\) exist")]
        public void GivenTheFollowingEventsExist(Table table)
        {
            var events = table.CreateSet<EventBuilder>()
                .Select(x => x.Build())
                .ToList();

            using(var context = new DataContext())
            {
                context.Events.AddRange(events);

                context.SaveChanges();
            }          
            
            ScenarioContext.Current.Set<IEnumerable<Event>>(events);

            //var events = table
            //    .CreateSet<EventBuilder>()
            //    .Select(x => x.Build())
            //    .Aggregate(
            //        new List<Dictionary<string, string>>(), 
            //        (aggregate, item)=> {
            //            aggregate.Add(
            //                new Dictionary<string, string> {
            //                    {"Id", item.Id.ToString()},
            //                    {"Name", item.Name},
            //                    {"OnSale", item.OnSale.ToString("O")},
            //                    {"DoorsOpen", item.DoorsOpen.ToString("O")},
            //                    {"Start", item.Start.ToString("O")},
            //                    {"End", item.End.ToString("O")}
            //                });
            //            return aggregate;
            //        });

            //_seeder.Seed("Events", events);

            //ScenarioContext.Current.Set<IEnumerable<Dictionary<string, string>>>(events);
        }

        [Given(@"the following tickets exist")]
        public void GivenTheFollowingTicketsExist(Table table)
        {
            //_seeder.Seed("Tickets", table);
        }

        [BeforeScenario]
        public void Setup()
        {
            using (var context = new DataContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Events DBCC CHECKIDENT('Events', RESEED, 0)");
                context.Database.ExecuteSqlCommand("DELETE FROM Tickets DBCC CHECKIDENT('Tickets', RESEED, 0)");
            }
        }
    }
}