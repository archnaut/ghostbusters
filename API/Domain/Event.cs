using System;

namespace API.Domain
{
    public class Event
    {
        public Event() { }

        public Event(string name, DateTime onSale, DateTime doorsOpen, DateTime start, DateTime end)
        {
            Name = name;
            OnSale = onSale;
            DoorsOpen = doorsOpen;
            Start = start;
            End = end;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime OnSale { get; private set; }
        public DateTime DoorsOpen { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}