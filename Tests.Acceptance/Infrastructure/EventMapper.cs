using System.Collections.Generic;
using System.Linq;
using CherrySeed.EntityDataProvider;
using Chronic;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Infrastructure
{
    internal class EventMapper : IEntityMapper
    {
        private readonly Parser _parser;

        public EventMapper()
        {
            _parser = new Parser();
        }

        public IEnumerable<EntityData> Map(Table table)
        {
            return new List<EntityData> {
                new EntityData {
                    EntityName = "Event",
                    Objects = table.Rows
                        .Select(Map)
                        .ToList()
                }
            };
        }

        public Dictionary<string, string> Map(TableRow row)
        {
            return new Dictionary<string, string> {
                { "Id", row["ID"]},
                { "Name", row["Name"]},
                { "OnSale", _parser.Parse(row["On Sale Date"]).ToTime().ToString("s")},
                { "DoorsOpen", _parser.Parse(row["Doors Open Date"]).ToTime().ToString("s")},
                { "Start", _parser.Parse(row["Event Start Date"]).ToTime().ToString("s")},
                { "End", _parser.Parse(row["Event End Date"]).ToTime().ToString("s")},
            };
        }

    }
}