using API.Domain;
using API.Infrastructure;
using BoDi;
using CherrySeed.Configuration;
using CherrySeed.Repositories.Ef;
using TechTalk.SpecFlow;

namespace Tests.Acceptance
{
    [Binding]
    public class CherrySeedSupport
    {
        private readonly IObjectContainer _container;

        public CherrySeedSupport(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void InitializeCherrySeed()
        {
            var repo = new EfRepository(() => new DataContext());

            var config = new CherrySeedConfiguration(x => {
                x.WithRepository(repo);
                x.WithDataProvider(new EventDataProvider());
               
                x.ForEntity<Event>()
                    .WithPrimaryKey(e => e.Id);

                x.ForEntity<Ticket>()
                    .WithPrimaryKey(e => e.Id)
                    .WithReference(e => e.EventId, typeof(Event));
            });

            var seeder = config.CreateSeeder();
            _container.RegisterInstanceAs(seeder);
        }
    }
}
