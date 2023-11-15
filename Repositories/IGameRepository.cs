using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Repositories
{
    public interface IGameRepository
    {
        Task<Game> AddGame(Game game);
        Task<Guid?> DeleteGame(Guid gameId);
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(Guid gameId);
        Task<bool> UpdateGame(Guid gameId, Game updatedGameData);
    }
}