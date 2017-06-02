using System.Collections.Generic;
using CherrySeed.EntityDataProvider;
using TechTalk.SpecFlow;

namespace Tests.Acceptance
{
    internal interface IEntityMapper
    {
        IEnumerable<EntityData> Map(Table table);
    }
}