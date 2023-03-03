namespace ConcertApp.Data.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDetail Detail { get; set; }
    }
}
