using CherrySeed;
using TechTalk.SpecFlow;

namespace Tests.Acceptance
{
    [Binding]
    public class TestData
    {
        private readonly CherrySeeder _seeder;

        public TestData(CherrySeeder seeder)
        {
            _seeder = seeder;
        }

        [Given(@"the following event\(s\) exist")]
        public void GivenTheFollowingEventsExist(Table table)
        {
            _seeder.Seed("Events", table);
        }

        [Given(@"the following tickets exist")]
        public void GivenTheFollowingTicketsExist(Table table)
        {
            _seeder.Seed("Tickets", table);
        }

        [BeforeScenario]
        public void Setup()
        {
            _seeder.Clear();
        }
    }
}