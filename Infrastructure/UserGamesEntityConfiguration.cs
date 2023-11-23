using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InternetGameShopAPI.Domain.UserAggregate;

namespace InternetGameShopAPI.Infrastructure
{
    public class UserGamesEntityConfiguration : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> builder)
        {
            //builder.Ignore(a => a.User);

            builder.ToTable("UserGames");
            builder.HasKey(c => new { c.User_id, c.Game_id });

            builder.HasOne(a => a.User)
               .WithMany(a => a.UserGames)
               .HasForeignKey(a => a.User_id);

            builder.Property(a => a.User_id)
                .HasColumnName("User_ID")
                .IsRequired()
                .HasMaxLength(255);

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