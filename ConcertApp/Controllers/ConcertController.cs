using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConcertApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcertController : Controller
    {
        private readonly IMediator _mediator;

        public ConcertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-concert")]
        public async Task<ActionResult<bool>> CreateConcert([FromBody] CreateConcertRequest request)
        {
            var result = await _mediator.Send(request.ToCommand());

            return Ok(result);
        }

        [HttpPost("add-participant")]
        public async Task<ActionResult<bool>> AddParticipant([FromBody] AddParticipantRequest request)
        {
            var result = await _mediator.Send(request.ToCommand());

            return Ok(result);
        }

        [HttpPost("remove-participant")]
        public async Task<ActionResult<bool>> RemoveParticipant([FromBody] RemoveParticipantRequest request)
        {
            var result = await _mediator.Send(request.ToCommand());

            return Ok(result);
        }

        [HttpPost("get-concerts")]
        public async Task<ActionResult<Page<Concert>>> GetConcerts([FromBody] GetPageRequest request)
        {
            var result = await _mediator.Send(request.ToQuery());

            return Ok(result);
        }

        [HttpPost("get-concert")]
        public async Task<ActionResult<ConcertDetails>> GetConcert([FromBody] GetConcertRequest request)
        {
            var result = await _mediator.Send(request.ToQuery());

            return Ok(result);
        }

        [HttpPost("get-upcoming-concerts")]
        public async Task<ActionResult<List<Concert>>> GetUpcomingConcerts([FromBody] GetUpcomingConcertsRequest request)
        {
            var result = await _mediator.Send(request.ToQuery());

            return Ok(result);
        }

        [HttpPost("get-recommendations")]
        public async Task<ActionResult<List<Concert>>> GetRecommendations([FromBody] GetRecommendationsRequest request)
        {
            var result = await _mediator.Send(request.ToQuery());

            return Ok(result);
        }
    }
}
