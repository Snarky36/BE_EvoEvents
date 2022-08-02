using System.Threading.Tasks;
using EvoEvents.API.Requests.Events;
using EvoEvents.API.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EvoEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-event")]
        public async Task<ActionResult<bool>> CreateEvent([FromBody] CreateEventRequest request)
        {
            var result = await _mediator.Send(request.ToCommand());

            return Ok(result);
        }
    }
}
