using ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Concerts.Queries;
using ConcertApp.Data;
using ConcertApp.Data.Models.UserConcerts;
using ConcertApp.Data.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Business.Concerts.Handlers
{
    public class GetUpcomingConcertsQueryHandler : IRequestHandler<GetUpcomingConcertsQuery, List<Concert>>
    {
        private readonly ConcertAppContext _context;

        public GetUpcomingConcertsQueryHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<List<Concert>> Handle(GetUpcomingConcertsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(x => x.Email == request.Email)
                .FirstOrDefaultAsync();

            ValidateUser(user);

            var currentDate = request.CurrentDate.ToUniversalTime();

            return await _context.Concerts
                .Where(x => EF.Functions.DateDiffDay(currentDate, x.StartDate) >= 0
                    && EF.Functions.DateDiffDay(currentDate, x.StartDate) <= 7
                    && x.UserConcerts.Any(c => c.UserStatus == UserStatus.Participant && c.UserId == user.Id))
                .ToConcertCard()
                .ToListAsync();
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
