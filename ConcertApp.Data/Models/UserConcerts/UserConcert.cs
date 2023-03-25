using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.Users;

namespace ConcertApp.Data.Models.UserConcerts
{
    public class UserConcert
    {
        public int Id { get; set; }
        public UserStatus UserStatus { get; set; }
        public int UserId { get; set; }
        public int ConcertId { get; set; }

        public User User { get; set; }
        public Concert Concert { get; set; }
    }
}
