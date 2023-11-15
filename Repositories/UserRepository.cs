using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using InternetGameShopAPI.Domain;
using InternetGameShopAPI.DTO;
using InternetGameShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<User> AddUser(CreateUserDTO user)
        {
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role,
                DateOfBirth = user.DateOfBirth
            };
            _databaseContext.Users.Add(newUser);
            await _databaseContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<Guid?> DeleteUser(Guid userId)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }

            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
            return userId;
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _databaseContext.Users.FindAsync(userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public async Task<User> ChangeUserData(Guid userId, UpdateUserDTO entityToUpdate)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            user.Password = entityToUpdate.Password;
            user.Email = entityToUpdate.Email;
            user.Username = entityToUpdate.Username;
            await _databaseContext.SaveChangesAsync();
            return user;
        }
    }
}