using ConcertApp.Data.Models.Concerts;
using MediatR;

namespace ConcertApp.Business.Concerts.Commands
{
    public class CreateConcertCommand: IRequest<bool>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public MusicGenre Genre { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
