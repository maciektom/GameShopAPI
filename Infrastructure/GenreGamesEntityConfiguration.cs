using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InternetGameShopAPI.Domain.GameAggregate;

namespace InternetGameShopAPI.Infrastructure
{
    public class GenerGamesEntityConfiguration : IEntityTypeConfiguration<GenreGames>
    {
        public void Configure(EntityTypeBuilder<GenreGames> builder)
        {
            builder.Ignore(a => a.Genre);

            builder.ToTable("GenreGames");
            builder.HasKey(c => c.Game_id);

            builder.HasOne(a => a.Genre)
               .WithMany(a => a.GenreGames)
               .HasForeignKey(a => a.Genre_id);

            builder.Property(a => a.Genre_id)
                .HasColumnName("Genre_ID")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(a => a.Title)
                .HasColumnName("Title")
                .IsRequired();

            builder.Property(a => a.Game_id)
                .HasColumnName("Game_ID")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}