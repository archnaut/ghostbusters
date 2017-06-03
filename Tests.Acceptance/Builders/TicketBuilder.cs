using API.Domain;

namespace Tests.Acceptance.Builders
{
    public class TicketBuilder
    {
        public int Id { get; set; } 
        public int EventId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

        public Ticket Build()
        {
            return new Ticket(Id, EventId, Name, Price, QuantityAvailable);
        }
    }
}