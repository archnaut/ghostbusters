using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Domain
{
    public class Event
    {
        public Event() { }

        public Event(string name, DateTime onSale, DateTime doorsOpen, DateTime start, DateTime end)
            :this(-1, name, onSale, doorsOpen, start, end) { }

        public Event(int id, string name, DateTime onSale, DateTime doorsOpen, DateTime start, DateTime end)
        {
            Id = id;
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

        public IEnumerable<TicketOrder> Purchase(int ticketId, int quantity, ITaxService taxService)
        {
            var ticket = Tickets.SingleOrDefault(x => x.Id == ticketId);

            if(ticket == null)
                throw new Exception($"Ticket with ID '{ticketId}' was not found.");

            return ticket.Purchase(taxService, quantity);
        }

        public virtual ICollection<Ticket> Tickets { get; private set; }
    }
}