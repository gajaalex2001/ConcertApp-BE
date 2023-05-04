using ConcertApp.Business.Users.Models;
using ConcertApp.Business.Users.Queries;
using ConcertApp.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Business.Users.Handlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserInformation>
    {
        private readonly ConcertAppContext _context;

        public LoginUserQueryHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<UserInformation> Handle (LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await GetUserForCredentials(request);

            ValidateUser(user);

            return user;
        }

        private async Task<UserInformation> GetUserForCredentials(LoginUserQuery request)
        {
            return await _context.Users
                .Where(x => x.Email == request.Email && x.Password == request.Password)
                .ToUserInformation()
                .FirstOrDefaultAsync();
        }

        private void ValidateUser(UserInformation user)
        {
            if (user == null)
            {
                throw new CustomException(ErrorCodes.User_AccountNotFound, UserErrors.WrongCredentials);
            }
        }
    }
}
