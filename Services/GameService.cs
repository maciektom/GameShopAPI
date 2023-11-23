using InternetGameShopAPI.Domain.GameAggregate;
using InternetGameShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Services
{
    public class GameService : IGameService

    {
        private readonly DatabaseContext _databaseContext;
        public GameService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Game> AddGame(GameViewModel gameViewModel)
        {
            var game = new Game
            {
                GameId = Guid.NewGuid(),
                Title = gameViewModel.Title,
                Description = gameViewModel.Description,
                Developer = gameViewModel.Developer,
                Platform = gameViewModel.Platform,
                ReleaseDate = gameViewModel.ReleaseDate,
                Price = gameViewModel.Price,
                //Genre = gameViewModel.Genre,
            };
            _databaseContext.Games.Add(game);
            await _databaseContext.SaveChangesAsync();
            return game;
        }
        public async Task<bool> DeleteGame(Guid GameId)
        {
            var game = await _databaseContext.Games.FindAsync(GameId);
            if (game == null)
            {
                return false;

            }

            _databaseContext.Games.Remove(game);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<Game> GetGameById(Guid gameId)
        {
            return await _databaseContext.Games.FindAsync(gameId);
        }
        public async Task<ICollection<Game>> GetAllGames()
        {
            {
                return await _databaseContext.Games.ToListAsync();
            }
        }

        public class GameViewModel
        {
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Developer { get; set; }
            public string Publisher { get; set; } = string.Empty;
            public string Platform { get; set; } = string.Empty;
            public DateTime ReleaseDate { get; set; }
            public float Price { get; set; }
            public string Genre { get; set; } = string.Empty;
        }
    }
}