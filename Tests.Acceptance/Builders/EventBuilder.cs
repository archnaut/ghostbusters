using API.Domain;
using Chronic;

namespace Tests.Acceptance.Model
{
    public class EventBuilder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Span OnSaleDate { get; set; }
        public Span DoorsOpenDate { get; set; }
        public Span EventStartDate { get; set; }
        public Span EventEndDate { get; set; }

        public Event Build()
        {
            return new Event(Id, Name, OnSaleDate.ToTime() , DoorsOpenDate.ToTime(), EventStartDate.ToTime(), EventEndDate.ToTime());
        }
    }
}