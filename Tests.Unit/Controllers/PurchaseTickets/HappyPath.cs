using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using API.Application;
using API.Controllers;
using API.Domain;
using API.DTO;
using FakeItEasy;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Unit.Controllers.PurchaseTickets
{
    public class HappyPath
    {
        private readonly HttpResponseMessage _response;
        private readonly dynamic _content;
        private readonly Order _order;
        private readonly Ticket _ticket01;
        private readonly Ticket _ticket02;
        private readonly OrderItem _order01;
        private readonly OrderItem _order02;
        private readonly CreditCard _creditCard;

        public HappyPath()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var eventService = A.Fake<IEventService>();

            _ticket01 = new Ticket(1, 1, "General Admission", 10.00M, 500);
            _ticket02 = new Ticket(2, 1, "VIP", 30.00M, 100);

            _creditCard = new CreditCard("Doc-Bob", "Haygreaser", "0000-0000-0000-0000", 123, 1, 2018);

            _order01 = new OrderItem(1, _ticket01, 0.98M);
            _order02 = new OrderItem(2, _ticket02, 0.98M);
            _order = new Order (
                1,
                _creditCard,
                DateTime.Now
            );
            
            new List<OrderItem> {_order01, _order02}
                .ForEach(x => _order.Add(x));

            var orderRequest = new OrderRequest {
                EventId = 1,
                FirstName = "Doc-Bob",
                LastName = "Haygreaser",
                CreditCardNumber = "0000-0000-0000-0000",
                SecurityCode = 123,
                ExpirationMonth = 1,
                ExpirationYear = 2018,
                Tickets = new[] {new OrderRequestItem(1, 1)}
            };

            A.CallTo(() => eventService.Submit(A<OrderRequest>.Ignored)).Returns( _order);

            var controller = new EventController(eventService) {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            _response = controller.PostOrder(orderRequest).ExecuteAsync(cancellationTokenSource.Token).Result;
            _content = JsonConvert.DeserializeObject<ExpandoObject>(_response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public void StatusCode()
        {
            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }

        [Fact]
        public void ContentType()
        {
            Assert.Equal("application/json", _response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public void CharSet()
        {
            Assert.Equal("utf-8", _response.Content.Headers.ContentType.CharSet);
        }

        [Fact]
        public void OrderId()
        {
            Assert.Equal(_order.Id, _content.OrderId);
        }

        [Fact]
        public void FirstName()
        {
            Assert.Equal(_creditCard.FirstName, _content.FirstName);
        }

        [Fact]
        public void LastName()
        {
            Assert.Equal(_creditCard.LastName, _content.LastName);
        }

        [Fact]
        public void PruchaseDate()
        {
            Assert.Equal(_order.PurchaseDate, _content.PurchaseDate);
        }

        [Fact]
        public void AmountPaid()
        {
            Assert.Equal(_order.AmountPaid, (decimal)_content.AmountPaid);
        }
        [Fact]
        public void Ticket01_Id()
        {
            Assert.Equal(_ticket01.Id, _content.Tickets[0].TicketId);
        }

        [Fact]
        public void Ticket01_Name()
        {
            Assert.Equal(_ticket01.Name, _content.Tickets[0].Name);
        }

        [Fact]
        public void Ticket01_Barcode()
        {
            Assert.Equal(_order01.Barcode, _content.Tickets[0].Barcode);
        }

        [Fact]
        public void Ticket01_AmountPaid()
        {
            Assert.Equal(_order01.AmountPaid, (decimal)_content.Tickets[0].TicketAmountPaid);
        }

        [Fact]
        public void Ticket01_SalesTax()
        {
            Assert.Equal(_order01.SalesTax, (decimal)_content.Tickets[0].SalesTaxPaid);
        }
        [Fact]
        public void Ticket02_Id()
        {
            Assert.Equal(_ticket02.Id, _content.Tickets[1].TicketId);
        }

        [Fact]
        public void Ticket02_Name()
        {
            Assert.Equal(_ticket02.Name, _content.Tickets[1].Name);
        }

        [Fact]
        public void Ticket02_Barcode()
        {
            Assert.Equal(_order02.Barcode, _content.Tickets[1].Barcode);
        }

        [Fact]
        public void Ticket02_AmountPaid()
        {
            Assert.Equal(_order02.AmountPaid, (decimal)_content.Tickets[1].TicketAmountPaid);
        }

        [Fact]
        public void Ticket02_SalesTax()
        {
            Assert.Equal(_order02.SalesTax, (decimal)_content.Tickets[1].SalesTaxPaid);
        }
    }
}