using System;
using System.ComponentModel.DataAnnotations;

namespace API.Domain
{
    public class OrderItem
    {
        private OrderItem()
        {
        }

        public OrderItem(Ticket ticket, decimal salesTax)
            :this(-1, ticket, salesTax) { }

        public OrderItem(int orderItemId, Ticket ticket,  decimal salesTax)
        {
            OrderItemId = orderItemId;
            TicketId = ticket.Id;
            Ticket = ticket;
            Barcode = Guid.NewGuid().ToString();
            AmountPaid = ticket.Price;
            SalesTax = salesTax;
        }

        [Key]
        public int OrderItemId { get; private set; }
        public int OrderId { get; private set; }
        public Order Order{get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; private set; }
        public string Barcode { get; private set; }
        public decimal AmountPaid { get; private set; }
        public decimal SalesTax { get; private set; }
    }
}