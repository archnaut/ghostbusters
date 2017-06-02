using System.Collections.Generic;
using CherrySeed;
using CherrySeed.Configuration.Exceptions;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Infrastructure
{
    public static class CherrySeedExtensionMethods
    {
        public static void Seed(this ICherrySeeder seeder, string entityName,  Table table)
        {
            var cherrySeeder = seeder as CherrySeeder;
            var dataProvider = cherrySeeder?.DataProvider as EventDataProvider;

            if (dataProvider == null)
            {
                throw new ConfigurationException("CherrySeed is misconfigured.", null);
            }

            dataProvider.ClearAndAdd(entityName, table);
            seeder.Seed();
        }

        public static void Seed(this ICherrySeeder seeder, string entityName, IEnumerable<Dictionary<string, string>> events)
        {
            var cherrySeeder = seeder as CherrySeeder;
            var dataProvider = cherrySeeder?.DataProvider as EventDataProvider;

            if (dataProvider == null)
            {
                throw new ConfigurationException("CherrySeed is misconfigured.", null);
            }

            dataProvider.ClearAndAdd(entityName, events);
            seeder.Seed();
        }

    }
}