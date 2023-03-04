using ConcertApp.Business.Users.Commands;
using ConcertApp.Business.Users.Queries;
using System.ComponentModel.DataAnnotations;

namespace ConcertApp.API.Requests.Users
{
    public static class UserExtensions
    {
        public static CreateUserCommand ToCommand(this CreateUserRequest request)
        {
            return new CreateUserCommand
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };
        }
        
        public static LoginUserQuery ToQuery(this LoginUserRequest request)
        {
            return new LoginUserQuery
            {
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
