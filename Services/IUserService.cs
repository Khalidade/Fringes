using Fringes.Models;

namespace Fringes.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(string id, User user);
        Task DeleteUser(string id);

    }
}
