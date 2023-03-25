using ConcertApp.Data.Models.UserConcerts;

namespace ConcertApp.Data.Models.Concerts
{
    public class Concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MusicGenre Genre { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<UserConcert> UserConcerts { get; set; }
    }
}
