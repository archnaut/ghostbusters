using System.Collections.Generic;
using API.Domain;
using API.DTO;

namespace API.Application
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();
        IEnumerable<Ticket> GetTickets(int eventId);
        Order Submit(OrderRequest orderRequest);
    }
}