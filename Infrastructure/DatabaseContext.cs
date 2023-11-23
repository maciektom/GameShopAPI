using InternetGameShopAPI.Domain.GameAggregate;
using InternetGameShopAPI.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternetGameShopAPI.Infrastructure
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<UserGame> UserGames { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new UserEntityConfiguration().Configure(builder.Entity<User>());
            new GameEntityConfiguration().Configure(builder.Entity<Game>());
            new UserGamesEntityConfiguration().Configure(builder.Entity<UserGame>());
        }
    }
}
