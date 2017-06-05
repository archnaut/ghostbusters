using System;
using API.Domain;

namespace Tests.Unit.TestData
{
    public class EventBuilder
    {
        private int _id;
        private string _name;
        private DateTime _onSale;
        private DateTime _doorsOpen;
        private DateTime _start;
        private DateTime _end;

        public EventBuilder()
        {
            var now = DateTime.Now;
            
            _id = 1;
            _name = "Annual Charity Event";
            _onSale = now.AddDays(-30);
            _doorsOpen = now.AddDays(4).AddHours(13);
            _start = now.AddDays(5).AddHours(14);
            _end = now.AddDays(5).AddHours(17);
        }

        public EventBuilder WithId(int id)
        {
            _id = id;

            return this;
        }

        public EventBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public EventBuilder WithOnSale(DateTime onSale)
        {
            _onSale = onSale;

            return this;
        }

        public EventBuilder WithDoorsOpen(DateTime doorsOpen)
        {
            _doorsOpen = doorsOpen;

            return this;
        }

        public EventBuilder WithStart(DateTime start)
        {
            _start = start;

            return this;
        }

        public EventBuilder WithEnd(DateTime end)
        {
            _end = end;

            return this;
        }

        public Event Build()
        {
            return new Event(_id, _name, _onSale, _doorsOpen, _start, _end);
        }
    }
}