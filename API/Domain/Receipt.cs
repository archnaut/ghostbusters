using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Domain
{
    public class Receipt
    {
        public Receipt(string firstName, string lastName, DateTime purchaseDate, IEnumerable<TicketOrder> tickets)
            : this(-1, firstName, lastName, purchaseDate, tickets) { }

        public Receipt(int id, string firstName, string lastName, DateTime purchaseDate, IEnumerable<TicketOrder> tickets)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PurchaseDate = purchaseDate;
            Tickets = tickets;
            AmountPaid = Math.Round(Tickets.Sum(x => x.SalesTax + x.Ticket.Price), 2);
        }

        public int Id { get; private set; } 
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal AmountPaid { get; private set; }
        public IEnumerable<TicketOrder> Tickets { get; private set; }
    }
}