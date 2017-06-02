using System.Collections.Generic;
using System.Linq;
using CherrySeed.EntityDataProvider;
using TechTalk.SpecFlow;

namespace Tests.Acceptance
{
    internal class DefaultMapper : IEntityMapper
    {
        private readonly string _entityName;

        public DefaultMapper(string entityName)
        {
            _entityName = entityName;
        }

        public IEnumerable<EntityData> Map(Table table)
        {
            return new List<EntityData>
            {
                new EntityData
                {
                    EntityName = _entityName,
                    Objects = table.Rows
                        .Select(r => r.ToDictionary(
                            instance => instance.Key,
                            instance => instance.Value)).ToList()
                }
            };
        }
    }
}