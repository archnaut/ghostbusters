namespace API.Domain
{
    public class TicketOrder
    {
        public TicketOrder(Ticket ticket, string barcode, decimal salesTax)
            :this(-1, ticket, barcode, salesTax) { }

        public TicketOrder(int id, Ticket ticket, string barcode, decimal salesTax)
        {
            Id = id;
            Ticket = ticket;
            Barcode = barcode;
            SalesTax = salesTax;
        }

        public int Id { get; private set; }
        public int TicketId => Ticket.Id; 
        public string Barcode { get; private set; }
        public decimal SalesTax { get; private set; }
        public Ticket Ticket { get; private set; }
    }
}