using ConcertApp.Business.Users.Commands;
using ConcertApp.Business.Users.Models;
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

        public static IQueryable<UserInformation> ToUserInformation(this IQueryable<User> query)
        {
            return query.Select(q => new UserInformation
            {
                Email = q.Email,
                FirstName = q.Detail.FirstName,
                LastName = q.Detail.LastName,
                PhoneNumber = q.Detail.PhoneNumber
            });
        }
    }
}
