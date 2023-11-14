//using InternetGameShopAPI.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace InternetGameShopAPI.Infrastructure
//{
//    public class DeveloperEntityConfiguration : IEntityTypeConfiguration<Developer>
//    {
//        public void Configure(EntityTypeBuilder<Developer> builder)
//        {
//            builder.ToTable("Developers");
//            builder.HasKey(g => g.DeveloperID);
//            builder.Property(g => g.DeveloperID)
//                .HasColumnName("Developer_ID")
//                .IsRequired();

//            builder.Property(g => g.Name)
//                .IsRequired()
//                .HasMaxLength(255);

//            builder.HasMany(d => d.)
//                .WithOne(g => g.Developer)
//                .HasForeignKey(g => DeveloperID);

//        }
//    }
//}
