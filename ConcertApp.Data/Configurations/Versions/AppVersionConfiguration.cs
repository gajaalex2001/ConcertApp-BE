using ConcertApp.Data.Models.Versions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcertApp.Data.Configurations.Versions
{
    public class AppVersionConfiguration : IEntityTypeConfiguration<AppVersion>
    {
        public void Configure(EntityTypeBuilder<AppVersion> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Version).IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(
                new AppVersion { Id = 1, Name = "Create Skeleton", Version = "1.0.1" }
            );

            builder.ToTable("ApplicationVersions");
        }
    }
}
