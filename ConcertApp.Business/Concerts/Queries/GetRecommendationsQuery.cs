using ConcertApp.Business.Concerts.Models;
using MediatR;

namespace ConcertApp.Business.Concerts.Queries
{
    public class GetRecommendationsQuery : IRequest<List<Concert>>
    {
        public string Email { get; set; }
    }
}
