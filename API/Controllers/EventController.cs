using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Application;
using API.Domain;
using API.DTO;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Events")]
        public IHttpActionResult GetEvents()
        {
            try
            {
                return Ok(
                    _service
                        .GetEvents()
                        .Select(x => new {
                            x.Id,
                            x.Name,
                            OnSaleDate = x.OnSale,
                            DoorOpenDate = x.DoorOpen,
                            EventStartDate = x.Start,
                            EventEndDate = x.End
                        }));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("Tickets/{eventId}")]
        public IHttpActionResult GetTickets(int eventId)
        {
            try
            {
                return Ok(
                    _service
                        .GetTickets(eventId)
                        .Select(x => new
                        {
                            x.Id,
                            x.Name,
                            x.Price
                        }));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("Orders")]
        public IHttpActionResult PostOrder(OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var order = _service.Submit(orderRequest);

                return Ok(new {
                    OrderId = order.Id,
                    order.CreditCard.FirstName,
                    order.CreditCard.LastName,
                    order.PurchaseDate,
                    order.AmountPaid,
                    Tickets = order.OrderItems.Select(x => new {
                        x.TicketId,
                        x.Ticket.Name,
                        x.Barcode,
                        TicketAmountPaid = x.AmountPaid,
                        SalesTaxPaid = x.SalesTax
                    })
                } );
            }
            catch (SoldOutException)
            {
                return Content(HttpStatusCode.BadRequest, "Sold Out: Insufficient tickets available to satisfy your request.");
            }
            catch (EventPassedException)
            {
                return Content(HttpStatusCode.BadRequest, "Event Passed: Cannot purchase tickets for events that have already passed.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}