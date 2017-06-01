using System.Linq;
using System.Web.Http;
using API.Domain;
using API.Infrastructure;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        private IRepository _repository;

        public EventController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Events")]
        public IHttpActionResult Get()
        {
            using (var dataContext = new DataContext())
                return Ok(dataContext.Events.ToList());
        }
    }
}
