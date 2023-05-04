using ConcertApp.Data.Models.Concerts;

namespace ConcertApp.Business.Concerts.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public MusicGenre Genre { get; set; }
        public int Capacity { get; set; }
        public int NoParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
