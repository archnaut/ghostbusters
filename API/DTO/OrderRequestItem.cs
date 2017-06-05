namespace API.DTO
{
    public class OrderRequestItem
    {
        public OrderRequestItem(int ticketId, int quantity)
        {
            TicketId = ticketId;
            Quantity = quantity;
        }

        public int TicketId { get; private set; }
        public int Quantity { get; private set; }
    }
}