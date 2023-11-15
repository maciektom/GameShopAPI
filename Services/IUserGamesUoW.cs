using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Services
{
    public interface IUserGamesUoW
    {
        Task<UserGames> DoWork(UserGames userGames);
    }
}