using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Services
{
    public class UserGamesService : IUserGamesService
    {
        private readonly DatabaseContext _databaseContext;
        public UserGamesService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        //ADD A GAME TO CERTAIN USER
        public async Task<UserGames> AddGameToUser(Guid userId, Guid gameId)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotImplementedException("User not found.");
            }
            var game = await _databaseContext.Games.FindAsync(gameId);
            if (game == null)
            {
                throw new NotImplementedException("Game not found.");
            }
            var userGame = new UserGames
            {
                User_id = userId,
                Game_id = gameId,
                Title = game.Title
            };
            await _databaseContext.UserGames.AddAsync(userGame);
            await _databaseContext.SaveChangesAsync();
            return  userGame;
        }
    }

}
