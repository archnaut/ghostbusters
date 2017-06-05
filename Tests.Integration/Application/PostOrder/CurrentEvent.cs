using System;
using System.Linq;
using API.Application;
using API.Domain;
using API.DTO;
using API.Infrastructure;
using Xunit;

namespace Tests.Integration.Application.PostOrder
{
    public class CurrentEvent
    {
        private const string FirstName = "Ooqdourx";
        private const string LastName = "Sha";
        private const string CreditCardNumber = "0000-0000-0000-0000";
        private const int SecurityCode = 123;
        private const int ExpirationMonth = 1;
        private const int ExpirationYear = 2018;
        private const int TicketId = 1;
        private readonly Order _order;

        public CurrentEvent()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();

            EffortProviderFactory.ResetDb();

            var today = DateTime.Now.Date;

            const int eventId = 1;
            const string eventName = "Current Event";

            var context = new DataContext();

            context.Events
                .Add(new Event(
                    eventId,
                    eventName,
                    today.AddDays(-30),
                    today.AddDays(4).AddHours(13),
                    today.AddDays(5).AddHours(14),
                    today.AddDays(5).AddHours(17)));

            context.Tickets.Add(new Ticket(eventId, "General Admission", 10.00M, 500));
            context.Tickets.Add(new Ticket(eventId, "VIP", 30.00M, 100));

            context.SaveChanges();

            var repository = new Repository(context);
            var eventService = new EventService(repository, new TaxService(0.0975M), new ConcurencyExceptionHandler(repository));

            var orderRequest = new OrderRequest
            {
                EventId = eventId,
                FirstName = FirstName,
                LastName = LastName,
                CreditCardNumber = CreditCardNumber,
                SecurityCode = SecurityCode,
                ExpirationMonth = ExpirationMonth,
                ExpirationYear = ExpirationYear,
                Tickets = new[] { new OrderRequestItem(TicketId, 1) }
            };

            _order = eventService.Submit(orderRequest);

        }

        [Fact]
        public void OrderId()
        {
            Assert.True(_order.Id > 0);
        }

        [Fact]
        public void ShouldIncludeFirstName()
        {
            Assert.Equal(FirstName, _order.CreditCard.FirstName);
        }

        [Fact]
        public void ShouldIncludeLastName()
        {
            Assert.Equal(LastName, _order.CreditCard.LastName);
        }

        [Fact]
        public void OrderShouldIncludePurchaseDate()
        {
            Assert.True(DateTime.Now.Subtract(_order.PurchaseDate).Minutes < 1);
        }

        [Fact]
        public void OrderShouldIncludeAmountPaid()
        {
            Assert.Equal(10.975M, _order.AmountPaid);
        }

        [Fact]
        public void OrderShouldIncludePurchasedTickets()
        {
           Assert.True(_order.OrderItems.Any()); 
        }

        [Fact]
        public void OrderItemShouldInlcudeTicketId()
        {
            Assert.True(_order.OrderItems.Any(x => x.TicketId == TicketId));
        }

        [Fact]
        public void OrderItemShouldInlcudeName()
        {
            Assert.True(_order.OrderItems.Any(x => x.Ticket.Name == "General Admission"));
        }

        [Fact]
        public void OrderItemShouldInlcudeBarcode()
        {
            Assert.True(_order.OrderItems.All(x => !string.IsNullOrEmpty(x.Barcode)));
        }

        [Fact]
        public void OrderItemShouldIncludeTicketAmoutPaid()
        {
            Assert.True(_order.OrderItems.Any(x=> x.AmountPaid == 10.00M));
        }

        [Fact]
        public void OrderItemShouldIncudeSalesTaxPaid()
        {
            Assert.True(_order.OrderItems.Any(x => x.SalesTax == 0.975M));
        }
    }
}