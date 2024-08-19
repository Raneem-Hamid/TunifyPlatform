using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class UserService : IUser
    {
        private readonly TunifyDbContext _context;

        public UserService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            _context.user.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(int userId)
        {

            var getUser = await GetUserById(userId);
            if (getUser != null)
            {
                throw new KeyNotFoundException("This User is not found.");
            }
            else
            {
                _context.user.Remove(getUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _context.user.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("This User is not found.");
            }
            else
            {
                return user;
            }
        }

        public async Task<User> UpdateUser(int userId, User user)
        {
            var existingUser = await _context.user.FindAsync(userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("This User is not found.");
            }
            else
            {
                existingUser = user;
                await _context.SaveChangesAsync();
                return user;
            }
        }
    }
}
