using InternetGameShopAPI.Domain;
using static InternetGameShopAPI.Services.UserService;

namespace InternetGameShopAPI.Services
{
    public interface IUserService
    {
        Task<User> AddUser(UserService.UserViewModel userViewModel);
        Task<bool> DeleteUser(Guid userId);
        Task<User> GetUserById (Guid userId);
        Task<List<User>> GetAllUsers();
        Task<bool> ChangeUserData(Guid userId, UserUpdateModel updatedUserData);

    }
}