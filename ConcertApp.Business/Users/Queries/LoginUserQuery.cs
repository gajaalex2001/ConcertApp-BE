using ConcertApp.Business.Users.Models;
using MediatR;

namespace ConcertApp.Business.Users.Queries
{
    public class LoginUserQuery : IRequest<UserInformation>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
