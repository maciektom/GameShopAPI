using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Infrastructure;

namespace InternetGameShopAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _databaseContext;
        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<User> AddUser(UserViewModel userViewModel)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = userViewModel.Username,
                Password = userViewModel.Password,
                Email = userViewModel.Email,
                Role = userViewModel.Role,
                DateOfBirth = userViewModel.DateOfBirth,
            };
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }
        public class UserViewModel
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; }
        }
    }
}
