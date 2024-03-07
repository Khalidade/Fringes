using Fringes.Models;
using Microsoft.EntityFrameworkCore;

namespace Fringes.Services
{
    public class UserService : IUserService
    {
        private readonly FringeAppDbContext _fringeAppDbContext;

        public UserService(FringeAppDbContext fringeAppDbContext)
        {
            _fringeAppDbContext = fringeAppDbContext;
        }
        public async Task<User> CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _fringeAppDbContext.Users.AddAsync(user);
            await _fringeAppDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(string id)
        {
            var user = await _fringeAppDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _fringeAppDbContext.Users.Remove(user);
                await _fringeAppDbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _fringeAppDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _fringeAppDbContext.Users.FindAsync(id);
        }

        public async Task<User> UpdateUser(string id, User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));

            }
            var existingUser = await _fringeAppDbContext.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;

            _fringeAppDbContext.Users.Update(existingUser);
            await _fringeAppDbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
