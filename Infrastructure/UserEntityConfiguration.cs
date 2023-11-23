using InternetGameShopAPI.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetGameShopAPI.Infrastructure
{
    public class UserEntityConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId)
                .HasColumnName("User_ID")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Username)
                .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u =>u.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength (255);

            builder.Property(u => u.Role)
                .HasColumnName("Role")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.DateOfBirth)
                .HasColumnName("Date Of Birth")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(u => u.UserGames)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.User_id);
        }
    }
}
