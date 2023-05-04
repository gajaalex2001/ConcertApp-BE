using BusinessModels = ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Pagination;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using MediatR;

namespace ConcertApp.Business.Concerts.Queries
{
    public class GetPageQuery : IRequest<Page<BusinessModels.Concert>>
    {
        public int PageIndex { get; set; }
        public int ItemsPerPage { get; set; }
        public MusicGenre? MusicGenre { get; set; }
        public string Email { get; set; }
        public UserStatus? UserStatus { get; set; }
    }
}
