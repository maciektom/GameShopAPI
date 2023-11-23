using InternetGameShopAPI.Domain.GameAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetGameShopAPI.Infrastructure
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder) 
        {
            builder.ToTable("Genre");
            builder.HasKey(g => g.GenreId);
            builder.Property(g => g.GenreId)
                .HasColumnName("Genre_ID")
                .IsRequired();


            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
