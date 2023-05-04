using ConcertApp.Business.Concerts.Commands;
using ConcertApp.Data;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using ConcertApp.Data.Models.Users;
using MediatR;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Business.Concerts.Handlers
{
    public class CreateConcertCommandHandler : IRequestHandler<CreateConcertCommand, bool>
    {
        private readonly ConcertAppContext _context;

        public CreateConcertCommandHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateConcertCommand command, CancellationToken cancellationToken)
        {
            var user = GetUser(command.Email);

            ValidateUser(user);

            var concert = CreateConcert(command, user);

            await _context.Concerts.AddAsync(concert);
            return await _context.SaveChangesAsync() > 0;
        }

        private User GetUser(string email)
        {
            return _context.Users
                .Where(x => x.Email == email)
                .FirstOrDefault();
        }

        private Concert CreateConcert(CreateConcertCommand cmd, User user)
        {
            var concert = cmd.ToConcert();
            concert.UserConcerts = new List<UserConcert> { new UserConcert
            {
                Concert = concert,
                UserStatus = UserStatus.Organizer,
                UserId = user.Id
            }};

            return concert;
        }

        private void ValidateUser(User user)
        {
            if (user == null)
            {
                throw new CustomException(ErrorCodes.User_AccountNotFound, UserErrors.NotFound);
            }
        }
    }
}
