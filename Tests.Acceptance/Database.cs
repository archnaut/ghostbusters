using System.Collections.Generic;
using System.Linq;
using API.Domain;
using API.Infrastructure;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tests.Acceptance.Builders;
using Tests.Acceptance.Model;

namespace Tests.Acceptance
{
    [Binding]
    public class Database
    {
        private readonly ScenarioContext _context;

        public Database(ScenarioContext context)
        {
            _context = context;
        }

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
            
            _context.Set<IEnumerable<Event>>(events);
        }

        [Given(@"the following tickets are available")]
        [Given(@"the following tickets exist")]
        public void GivenTheFollowingTicketsExist(Table table)
        {
            var tickets = table.CreateSet<TicketBuilder>()
                .Select(x => x.Build())
                .ToList();

            using (var context = new DataContext())
            {
                context.Tickets.AddRange(tickets);
                context.SaveChanges();
            }
        }

        [BeforeScenario]
        public static void Setup()
        {
            using (var context = new DataContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Events DBCC CHECKIDENT('Events', RESEED, 0)");
                context.Database.ExecuteSqlCommand("DELETE FROM Tickets DBCC CHECKIDENT('Tickets', RESEED, 0)");
            }
        }
    }
}