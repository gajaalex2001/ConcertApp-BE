using ConcertApp.Data.Configurations.Users;
using ConcertApp.Data.Configurations.Versions;
using ConcertApp.Data.Models.Users;
using ConcertApp.Data.Models.Versions;
using Microsoft.EntityFrameworkCore;

namespace ConcertApp.Data
{
    public class ConcertAppContext : DbContext
    {
        public ConcertAppContext() { }

        public ConcertAppContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<AppVersion> AppVersions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UsersDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppVersionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserDetailConfiguration());
        }
    }
}
