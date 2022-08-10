using System.Threading.Tasks;
using EvoEvents.API.Requests.Events;
using EvoEvents.API.Requests.Events.Reservations;
using EvoEvents.API.Requests.Users;
using EvoEvents.Business.Events.Models;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<EventInformation>> ViewEvent([FromRoute] ViewEventRequest request)
        {
            var result = await _mediator.Send(request.ToQuery());

            return Ok(result);
        }

        [HttpPost("{eventid}/register")]
        public async Task<ActionResult<bool>> RegisterEvent(CreateReservationRequest request)
        {
            var result = await _mediator.Send(request.ToCommand());

            return Ok(result);
        }
    }
}