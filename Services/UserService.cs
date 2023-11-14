using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _databaseContext;


        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        //ADD USER
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

        //DELETE USER
        public async Task<bool> DeleteUser(Guid UserId)
        {
            var user = await _databaseContext.Users.FindAsync(UserId);
            if (user == null)
            {
                return false;

            }

            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        //FIND USER BY ID
        public async Task<User> GetUserById(Guid userId)
        {
            return await _databaseContext.Users.FindAsync(userId);
        }
        
        //GET ALL USERS
        public async Task<List<User>>GetAllUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        //CHANGE USER DATA
        public async Task<bool> ChangeUserData(Guid userId, UserUpdateModel updatedUserData)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }
            user.Username = updatedUserData.Username;
            user.Password = updatedUserData.Password;
            user.Email = updatedUserData.Email;

            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public class UserViewModel
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; }
        }
        
      public class UserUpdateModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }

        }
       
    }
}
