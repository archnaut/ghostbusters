using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using API.Domain;

namespace API.Presentaion
{
    public class EventPresenter
    {
        private readonly IRepository _repository;
        private readonly ITaxService _taxService;

        public EventPresenter(IRepository repository, ITaxService taxService)
        {
            _repository = repository;
            _taxService = taxService;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _repository.Find<Event>(x => x.End > DateTime.Now);
        }

        public IEnumerable<Dictionary<string, object>> GetTickets(int eventId)
        {
            return _repository
                .Find<Ticket>(x => x.EventId == eventId)
                .Select(
                    x => new Dictionary<string, object>
                    {
                        {"Id", x.Id},
                        {"Name", x.Name},
                        {"Price", x.Price}
                    });
        }

        public Receipt Submit(PurchaseOrder order)
        {
            bool saveFailed;

            do
            {
                saveFailed = false;

                try
                {
                    using (var unitOfWork = _repository.NewUnitOfWork())
                    {
                        var @event = _repository.Single<Event>(x => x.Id == order.EventId);

                        if (@event == null)
                            throw new Exception($"Event ID '{order.EventId}' was not found.");

                        var tickets = order.Tickets
                            .SelectMany(x => @event.Purchase(x["TicketId"], x["Quantity"], _taxService));

                        var receipt = new Receipt(order.FirstName, order.LastName, DateTime.Now, tickets);

                        unitOfWork.Commit();

                        return receipt;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
            } while (saveFailed);

            return null;
        }
    }
}