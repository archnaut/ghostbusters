using System;
using System.Collections.Generic;
using System.Linq;
using API.Domain;
using API.DTO;
using API.Infrastructure;

namespace API.Application
{
    public class EventService : IEventService
    {
        private readonly IConcurencyExceptionHandler _concurencyExceptionHandler;
        private readonly IRepository _repository;
        private readonly ITaxService _taxService;

        public EventService(IRepository repository, ITaxService taxService, IConcurencyExceptionHandler concurencyExceptionHandler)
        {
            _repository = repository;
            _taxService = taxService;
            _concurencyExceptionHandler = concurencyExceptionHandler;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _repository.Find<Event>(x => x.End > DateTime.Now);
        }

        public IEnumerable<Ticket> GetTickets(int eventId)
        {
            return _repository.Find<Ticket>(x => x.Event.End > DateTime.Now && x.EventId == eventId);
        }

        public Order Submit(OrderRequest orderRequest)
        {
            return _concurencyExceptionHandler.Commit(() => Commit(orderRequest));
        }

        private Order Commit(OrderRequest orderRequest)
        {
            var @event = GetEvent(orderRequest.EventId);
            var creditCard = GetCreditCard(orderRequest);


            var order = new Order(creditCard, DateTime.Now);

            orderRequest.Tickets
                .SelectMany(x => @event.Purchase(x.TicketId, x.Quantity, _taxService))
                .ToList()
                .ForEach(x => order.Add(x));

            _repository.AddOrUpdate(order);

            return order;
        }

        private CreditCard GetCreditCard(OrderRequest orderRequest)
        {
            var creditCard = _repository.Single<CreditCard>(x => x.Number == orderRequest.CreditCardNumber);

            if (creditCard == null)
            {
                creditCard = new CreditCard(orderRequest.FirstName, orderRequest.LastName,
                    orderRequest.CreditCardNumber, orderRequest.SecurityCode, orderRequest.ExpirationMonth,
                    orderRequest.ExpirationYear);
            }
            else
            {
                creditCard.Update(
                    orderRequest.FirstName,
                    orderRequest.LastName,
                    orderRequest.SecurityCode,
                    orderRequest.ExpirationMonth,
                    orderRequest.ExpirationYear);
            }

            _repository.AddOrUpdate(creditCard);

            return creditCard;
        }

        private Event GetEvent(int eventId)
        {
            var @event = _repository.Single<Event>(x => x.Id == eventId);

            if (@event == null)
                throw new Exception($"Event ID '{eventId}' was not found.");
            return @event;
        }
    }
}