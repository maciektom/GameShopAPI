using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.DTO;

namespace InternetGameShopAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(Guid userId);
        Task<Guid?> DeleteUser(Guid userId);
        void Dispose();
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
    }
}