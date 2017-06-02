﻿using System.Collections.Generic;
using System.Linq;
using CherrySeed.EntityDataProvider;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Infrastructure
{
    public class EventDataProvider : IDataProvider
    {
        private readonly MapperFactory _mapperFactory;
        private List<EntityData> _entityData;

        public EventDataProvider()
        {
            _mapperFactory = new MapperFactory();
            _entityData = new List<EntityData>();
        }

        public void ClearAndAdd(string entityName, Table table)
        {
            var mapper = _mapperFactory.Create(entityName);
            _entityData = mapper.Map(table).ToList();
        }

        public void ClearAndAdd(string entityName, IEnumerable<Dictionary<string, string>> dictionaries)
        {
            _entityData = new List<EntityData> {
                new EntityData {
                    EntityName = entityName,
                    Objects = dictionaries.ToList()
                }
            };
        }

        public List<EntityData> GetEntityDataList()
        {
            return _entityData;
        }
    }
}