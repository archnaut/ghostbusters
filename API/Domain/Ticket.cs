using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Domain
{
    public class Ticket
    {
        private Ticket()
        {
        }

        public Ticket(int eventId, string name, decimal price, int quantityAvailable)
            :this(-1, eventId, name, price, quantityAvailable)
        {
        }

        public Ticket(int id, int eventId, string name, decimal price, int quantityAvailable)
        {
            Id = id;
            EventId = eventId;
            Name = name;
            Price = price;
            QuantityAvailable = quantityAvailable;
        }

        public int Id { get; private set; }
        public int EventId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityAvailable { get; private set; }

        public IEnumerable<TicketOrder> Purchase(ITaxService taxService, int quantity)
        {
            if (quantity < 0 || quantity > 8) {
               throw new ArgumentOutOfRangeException(nameof(quantity), "Purchases must be for 1 to 8 tickets."); 
            }

            if (QuantityAvailable < quantity) {
               throw new Exception($"Insufficient quantity available to fulfill order."); 
            }

            var salesTax = taxService.TaxFor(Price);
            QuantityAvailable -= quantity;

            return Enumerable
                .Range(1, quantity)
                .Select(x => new TicketOrder(this, string.Empty, salesTax));
        }
    }
}