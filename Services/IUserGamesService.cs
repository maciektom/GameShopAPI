using InternetGameShopAPI.Domain.UserAggregate;

namespace InternetGameShopAPI.Services
{
    public interface IUserGamesService
    {
        Task<UserGame> AddGameToUser(Guid userId, Guid gameId);
    }
}