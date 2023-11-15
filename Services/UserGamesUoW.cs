using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Infrastructure;

namespace InternetGameShopAPI.Services
{
    public class UserGamesUoW : IUserGamesUoW
    {
        private readonly DatabaseContext _databaseContext;
        public UserGamesUoW(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<UserGames> DoWork(UserGames userGames)
        {
            _databaseContext.UserGames.Add(userGames);
            await _databaseContext.SaveChangesAsync();
            return userGames;
        }
    }
}