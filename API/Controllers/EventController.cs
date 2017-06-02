using System.Linq;
using System.Web.Http;
using API.Domain;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        private readonly IRepository _repository;

        public EventController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Events")]
        public IHttpActionResult GetEvents()
        {
            return Ok(_repository.All<Event>());
        }

        [HttpGet]
        [Route("Tickets/{eventId}")]
        public IHttpActionResult GetTickets(int eventId)
        {
            return Ok(_repository.Find<Ticket>(x => x.Event.Id == eventId).Select(x => new {x.Id, x.Name, x.Price}));
        }
    }
}