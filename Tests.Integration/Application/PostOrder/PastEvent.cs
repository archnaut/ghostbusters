using System;
using API.Application;
using API.Domain;
using API.DTO;
using API.Infrastructure;
using Xunit;

namespace Tests.Integration.Application.PostOrder
{
    public class PastEvent
    {
        private const string FirstName = "Ooqdourx";
        private const string LastName = "Sha";
        private const string CreditCardNumber = "0000-0000-0000-0000";
        private const int SecurityCode = 123;
        private const int ExpirationMonth = 1;
        private const int ExpirationYear = 2018;
        private const int TicketId = 1;
        private const int EventId = 1;
        private readonly EventService _eventService;

        public PastEvent()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();

            EffortProviderFactory.ResetDb();

            var today = DateTime.Now.Date;

            const string eventName = "Current Event";


            var context = new DataContext();

            context.Events
                .Add(new Event(
                    EventId,
                    eventName,
                    today.AddDays(-35),
                    today.AddDays(-5).AddHours(11),
                    today.AddDays(-4).AddHours(9),
                    today.AddDays(-4).AddHours(7)));

            context.Tickets.Add(new Ticket(EventId, "General Admission", 10.00M, 500));
            context.Tickets.Add(new Ticket(EventId, "VIP", 30.00M, 100));

            context.SaveChanges();

            var repository = new Repository(context);
            _eventService = new EventService(repository, new TaxService(0.0975M), new ConcurencyExceptionHandler(repository));
        }

        [Fact]
        public void ShouldThrowException()
        {
            var orderRequest = new OrderRequest
            {
                EventId = EventId,
                FirstName = FirstName,
                LastName = LastName,
                CreditCardNumber = CreditCardNumber,
                SecurityCode = SecurityCode,
                ExpirationMonth = ExpirationMonth,
                ExpirationYear = ExpirationYear,
                Tickets = new[] { new OrderRequestItem(TicketId, 1) }
            };

            Assert.Throws<EventPassedException>(()=>_eventService.Submit(orderRequest));
        }
    }
}