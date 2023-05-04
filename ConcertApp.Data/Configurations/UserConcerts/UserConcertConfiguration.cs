using ConcertApp.Data.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ConcertApp.Data.Models.UserConcerts;

namespace ConcertApp.Data.Configurations.UserConcerts
{
    public class UserConcertConfiguration : IEntityTypeConfiguration<UserConcert>
    {
        public void Configure(EntityTypeBuilder<UserConcert> builder)
        {
            builder.ToTable("UserConcerts");
        }
    }
}
