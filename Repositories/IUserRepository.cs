using InternetGameShopAPI.Domain;
using InternetGameShopAPI.DTO;

namespace InternetGameShopAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(CreateUserDTO user);
        Task<User> ChangeUserData(Guid userId,UpdateUserDTO entityToUpdate);
        Task<Guid?> DeleteUser(Guid userId);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
    }
}