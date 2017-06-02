using System;
using System.Collections.Generic;
using Chronic;
using TechTalk.SpecFlow.Assist;

namespace Tests.Acceptance.Infrastructure
{
    public class SpanValueRetriever : IValueRetriever
    {
        private readonly Parser _parser;

        public SpanValueRetriever()
        {
            _parser = new Parser();
        }

        public bool CanRetrieve(KeyValuePair<string,string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof (Span);
        }

        public object Retrieve(KeyValuePair<string,string> keyValuePair, Type targetType, Type propertyType)
        {
            return _parser.Parse(keyValuePair.Value);
        }
    }
}