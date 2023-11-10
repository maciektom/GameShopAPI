using InternetGameShopAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternetGameShopAPI.Infrastructure
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DatabaseContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new UserEntityConfiguration().Configure(builder.Entity<User>());
            new GameEntityConfiguration().Configure(builder.Entity<Game>());
        }
    }
}
