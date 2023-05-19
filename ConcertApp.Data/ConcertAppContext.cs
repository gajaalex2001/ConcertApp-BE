using ConcertApp.Data.Configurations.Concerts;
using ConcertApp.Data.Configurations.Users;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using ConcertApp.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ConcertApp.Data
{
    public class ConcertAppContext : DbContext
    {
        public ConcertAppContext() { }

        public ConcertAppContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UsersDetails { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }
        public virtual DbSet<UserConcert> UserConcerts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserDetailConfiguration());
            builder.ApplyConfiguration(new ConcertConfiguration());
        }
    }
}
