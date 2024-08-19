using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int userId , User user);
        Task DeleteUser(int userId);
    }
}
