using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DatabaseContext _databaseContext;

        public GameRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Game>  AddGame(Game game)
        {
            _databaseContext.Games.Add(game);
            await _databaseContext.SaveChangesAsync();
            return game;
        }

        public async Task<Guid?> DeleteGame(Guid gameId)
        {
            var game = await _databaseContext.Games.FindAsync(gameId);
            if (game == null)
            {
                return null; // or throw an exception if you prefer
            }

            _databaseContext.Games.Remove(game);
            await _databaseContext.SaveChangesAsync();
            return gameId;
        }

        public async Task<Game> GetGameById(Guid gameId)
        {
            return await _databaseContext.Games.FindAsync(gameId);
        }

        public async Task<List<Game>> GetAllGames()
        {
            return await _databaseContext.Games.ToListAsync();
        }

        public async Task<bool> UpdateGame(Guid gameId, Game updatedGameData)
        {
            var game = await _databaseContext.Games.FindAsync(gameId);
            if (game == null)
            {
                return false;
            }

            game.Title = updatedGameData.Title;
            game.Description = updatedGameData.Description;
            game.Developer = updatedGameData.Developer;
            game.Publisher = updatedGameData.Publisher;
            game.Platform = updatedGameData.Platform;
            game.ReleaseDate = updatedGameData.ReleaseDate;
            game.Price = updatedGameData.Price;
            game.Genre = updatedGameData.Genre;

            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}