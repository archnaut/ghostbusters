using System.Linq;
using System.Web.Http;
using API.Infrastructure;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("Events")]
        public IHttpActionResult Get()
        {
            var dataContext = new DataContext();
            return Ok(dataContext.Events.ToList());
        }
    }
}
