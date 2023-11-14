using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Services
{
    public interface IGameService
    {
        Task<Game> AddGame(GameService.GameViewModel gameViewModel);
        Task<bool> DeleteGame(Guid gameId);
        Task<Game> GetGameById(Guid gameId);
        Task<ICollection<Game>> GetAllGames();

    }
}
