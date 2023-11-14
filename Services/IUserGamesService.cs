using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Services
{
    public interface IUserGamesService
    {
        Task<UserGames> AddGameToUser(Guid userId, Guid gameId);
    }
}