using InternetGameShopAPI.Domain.UserAggregate;

namespace InternetGameShopAPI.Services
{
    public interface IUserGamesUoW
    {
        Task<UserGame> DoWork(UserGame userGames);
    }
}