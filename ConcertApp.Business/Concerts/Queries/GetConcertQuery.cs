using ConcertApp.Business.Concerts.Models;
using MediatR;

namespace ConcertApp.Business.Concerts.Queries
{
    public class GetConcertQuery : IRequest<ConcertDetails>
    {
        public int ConcertId { get; set; }
    }
}
