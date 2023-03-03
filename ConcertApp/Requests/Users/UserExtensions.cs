using ConcertApp.Business.Users.Commands;

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
    }
}
