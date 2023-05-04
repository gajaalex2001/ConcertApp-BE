using ConcertApp.Business.Concerts.Commands;
using ConcertApp.Data;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using ConcertApp.Data.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Business.Concerts.Handlers
{
    public class AddParticipantCommandHandler : IRequestHandler<AddParticipantCommand, bool>
    {
        private readonly ConcertAppContext _context;

        public AddParticipantCommandHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle (AddParticipantCommand command, CancellationToken cancellationToken)
        {
            var user = GetUser(command.Email);

            ValidateUser(user);

            var concert = GetConcert(command.ConcertId);

            ValidateConcert(concert);

            var userConcert = GetUserConcert(user, concert);

            ValidateUserStatus(userConcert);

            await _context.UserConcerts.AddAsync(new UserConcert
            {
                UserId = user.Id,
                ConcertId = concert.Id,
                UserStatus = UserStatus.Participant
            });

            return await _context.SaveChangesAsync() > 0;
        }

        private User GetUser(string email)
        {
            return _context.Users
                .Where(x => x.Email == email)
                .FirstOrDefault();
        }

        private void ValidateUser(User user)
        {
            if (user == null)
            {
                throw new CustomException(ErrorCodes.User_AccountNotFound, UserErrors.NotFound);
            }
        }

        private Concert GetConcert(int concertId)
        {
            return _context.Concerts
                .Where(x => x.Id == concertId)
                .Include(x => x.UserConcerts)
                .FirstOrDefault();
        }

        private void ValidateConcert (Concert concert)
        {
            if (concert == null)
            {
                throw new CustomException(ErrorCodes.Concert_NotFound, ConcertErrors.NotFound);
            }

            if (concert.StartDate < DateTime.UtcNow)
            {
                throw new CustomException(ErrorCodes.Concert_PassedConcert, ConcertErrors.ConcertInThePast);
            }

            if (concert.UserConcerts.Count - 1 == concert.Capacity)
            {
                throw new CustomException(ErrorCodes.Concert_CapacityReached, ConcertErrors.CapacityReached);
            }
        }

        private UserConcert GetUserConcert(User user, Concert concert)
        {
            return _context.UserConcerts
               .Where(x => x.ConcertId == concert.Id && x.UserId == user.Id)
               .FirstOrDefault();
        }

        private void ValidateUserStatus (UserConcert userConcert)
        {

            if (userConcert != null)
            {
                if (userConcert.UserStatus == UserStatus.Participant)
                {
                    throw new CustomException(ErrorCodes.Concert_AlreadyParticipating, ConcertErrors.UserAlreadyParticipating);
                }

                throw new CustomException(ErrorCodes.Concert_UserIsOrganizing, ConcertErrors.UserIsOrganizing);
            }
        }
    }
}
