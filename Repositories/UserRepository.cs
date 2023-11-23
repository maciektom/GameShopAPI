using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using InternetGameShopAPI.Domain.UserAggregate;
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

        public async Task<User> AddUser(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return user;
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

        public async Task<User> UpdateUser(Guid userId, UpdateUserDTO entityToUpdate)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}