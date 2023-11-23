using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Services
{
    public class UserGamesUoW : IUserGamesUoW
    {
        private readonly DatabaseContext _databaseContext;
        public UserGamesUoW(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<UserGame> DoWork(UserGame userGames)
        {
            var existingUserGame = await _databaseContext.UserGames
        .FirstOrDefaultAsync(ug => ug.User_id == userGames.User_id && ug.Game_id == userGames.Game_id);

            if (existingUserGame != null)
            {
                throw new Exception("User already owns this game.");
            }
            _databaseContext.UserGames.Add(userGames);
            await _databaseContext.SaveChangesAsync();
            return userGames;
        }
    }
}

