using System.Web.Http;
using API.Presentaion;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        private readonly EventPresenter _presenter;

        public EventController(EventPresenter presenter)
        {
            _presenter = presenter;
        }

        [HttpGet]
        [Route("Events")]
        public IHttpActionResult GetEvents()
        {
            return Ok(_presenter.GetEvents());
        }

        [HttpGet]
        [Route("Tickets/{eventId}")]
        public IHttpActionResult GetTickets(int eventId)
        {
            return Ok(_presenter.GetTickets(eventId));
        }

        [HttpPost]
        [Route("Orders")]
        public IHttpActionResult PostPurchaseOrder(PurchaseOrder order)
        {
            return Ok(_presenter.Submit(order));
        }
    }
}