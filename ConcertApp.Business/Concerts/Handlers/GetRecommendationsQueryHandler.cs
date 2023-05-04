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
    public class GetRecommendationsQueryHandler : IRequestHandler<GetRecommendationsQuery, List<Concert>>
    {
        private readonly ConcertAppContext _context;

        public GetRecommendationsQueryHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<List<Concert>> Handle(GetRecommendationsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(x => x.Email == request.Email)
                .FirstOrDefaultAsync();

            ValidateUser(user);

            var genres = await _context.UserConcerts
                .Where(x => x.UserId == user.Id && x.UserStatus == UserStatus.Participant)
                .Select(x => x.Concert.Genre)
                .Distinct()
                .Take(3)
                .ToListAsync();

            List<Concert> concerts = await _context.Concerts
                .Include(x => x.UserConcerts)
                .Where(x => x.UserConcerts.All(c => c.UserId != user.Id && genres.Contains(c.Concert.Genre)))
                .Take(5)
                .ToConcertCard()
                .ToListAsync();

            if (concerts.Count == 0)
            {
                return await _context.Concerts
                    .Include(x => x.UserConcerts)
                    .Where(x => x.UserConcerts.All(c => c.UserId != user.Id))
                    .Take(5)
                    .ToConcertCard()
                    .ToListAsync();
            }

            return concerts;
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
