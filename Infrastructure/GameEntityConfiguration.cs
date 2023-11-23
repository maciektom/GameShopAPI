using InternetGameShopAPI.Domain.GameAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetGameShopAPI.Infrastructure
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");
            builder.HasKey(g => g.GameId);
            builder.Property(g => g.GameId)
                .HasColumnName("Game_ID")
                .IsRequired();

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(g => g.Description)
                .IsRequired();

            builder.Property(g => g.Developer)
                .IsRequired();


            builder.Property(g => g.Platform)
                .IsRequired();

            builder.Property(g => g.ReleaseDate)
                .IsRequired();

            builder.Property(g => g.Price)
                .IsRequired();
           
            builder.Property(g => g.Genre)
               .IsRequired()
               .HasConversion(
                   genre => genre.Name,            // Convert Genre to string for database
                   name => new Genre(Guid.NewGuid(), name)  // Convert string from database to Genre
               );
        }
    }
}
