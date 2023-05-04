using BusinessModels = ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Concerts.Queries;
using ConcertApp.Business.Pagination;
using ConcertApp.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ConcertApp.Data.Models.Concerts;

namespace ConcertApp.Business.Concerts.Handlers
{
    public class GetPageQueryHandler : IRequestHandler<GetPageQuery, Page<BusinessModels.Concert>>
    {
        private readonly ConcertAppContext _context;

        public GetPageQueryHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<Page<BusinessModels.Concert>> Handle (GetPageQuery request, CancellationToken cancellationToken)
        {
            var concerts = _context.Concerts;

            var filteredConcerts = ApplyFilters(request, concerts);

            var items = await filteredConcerts.OrderBy(x => x.Id)
                .Skip((request.PageIndex - 1) * request.ItemsPerPage)
                .Take(request.ItemsPerPage)
                .ToConcertCard()
                .ToListAsync();

            return new Page<BusinessModels.Concert>
            {
                Items = items,
                NoItems = concerts.Count()
            };
        }

        private IQueryable<Concert> ApplyFilters(GetPageQuery request, IQueryable<Concert> concerts)
        {
            if (request.UserStatus != null)
            {
                concerts = concerts.Where(x => x.UserConcerts.Any(uc => uc.User.Email == request.Email && uc.UserStatus == request.UserStatus));
            }

            if (request.MusicGenre != null)
            {
                concerts = concerts.Where(x => x.Genre == request.MusicGenre);
            }

            return concerts;
        }
    }
}
