using ConcertApp.Business.Concerts.Models;
using MediatR;

namespace ConcertApp.Business.Concerts.Queries
{
    public class GetUpcomingConcertsQuery : IRequest<List<Concert>>
    {
        public string Email { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
