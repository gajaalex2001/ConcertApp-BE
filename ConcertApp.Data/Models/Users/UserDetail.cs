﻿namespace ConcertApp.Data.Models.Users
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
