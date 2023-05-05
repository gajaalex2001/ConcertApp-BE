using ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Concerts.Queries;
using ConcertApp.Business.Users;
using ConcertApp.Data;
using ConcertApp.Data.Models.UserConcerts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Business.Concerts.Handlers
{
    public class GetConcertQueryHandler : IRequestHandler<GetConcertQuery, ConcertDetails>
    {
        private readonly ConcertAppContext _context;

        public GetConcertQueryHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<ConcertDetails> Handle(GetConcertQuery request, CancellationToken cancellationToken)
        {
            var concert = await _context.Concerts
                .Where(x => x.Id == request.ConcertId)
                .Include(x => x.UserConcerts)
                .ToConcertDetails()
                .FirstOrDefaultAsync();

            ValidateConcert(concert);

            var organizer = await _context.Users
                .Include(x => x.UserConcerts)
                .Where(x => x.UserConcerts.Any(c => c.ConcertId == request.ConcertId && c.UserStatus == UserStatus.Organizer))
                .ToUserInformation()
                .FirstOrDefaultAsync();

            concert.Organizer = organizer;

            return concert;
        }

        private void ValidateConcert(ConcertDetails concert)
        {
            if (concert is null)
            {
                throw new CustomException(ErrorCodes.Concert_NotFound, ConcertErrors.NotFound);
            }
        }
    }
}
