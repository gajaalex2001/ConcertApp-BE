using ConcertApp.Business.Users.Commands;
using ConcertApp.Data.Models.Users;

namespace ConcertApp.Business.Users
{
    public static class UserExtensions
    {
        public static User ToUser(this CreateUserCommand command)
        {
            return new User
            {
                Email = command.Email,
                Password = command.Password,
                Detail = new UserDetail
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    PhoneNumber = command.PhoneNumber
                }
            };
        }
    }
}
