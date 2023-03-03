using ConcertApp.API.Requests.Versions;
using ConcertApp.Business.Versions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConcertApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        private readonly IMediator _mediator;

        public VersionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-version")]
        public async Task<ActionResult<string>> GetVersion([FromQuery] GetVersionQuery request)
        {
            var result = await _mediator.Send(request.ToQuery());

            return Ok(result);
        }
    }
}
