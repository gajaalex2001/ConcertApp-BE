using ConcertApp.API.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConcertApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("create-user")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _mediator.Send(request.ToCommand());

            return Ok(result);
        }
    }
}
