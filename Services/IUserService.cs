using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Services
{
    public interface IUserService
    {
        Task<User> AddUser(UserService.UserViewModel userViewModel);
    }
}