namespace API.Domain
{
    public class Ticket
    {
        private Ticket()
        {
        }

        public Ticket(int eventId, string name, decimal price)
        {
            EventId = eventId;
            Name = name;
            Price = price;
        }

        public int Id { get; private set; }
        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}