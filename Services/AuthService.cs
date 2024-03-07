using Fringes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fringes.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly FringeAppDbContext _fringeAppDbContext;

        public AuthService(UserManager<User> userManager, IConfiguration config, FringeAppDbContext fringeAppDbContext)
        {
            _userManager = userManager;
            _config = config;
            _fringeAppDbContext = fringeAppDbContext;
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _fringeAppDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> loginAsync(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginViewModel.Password))
            {
                return null;
            }
            return user;
        }



        public Task LogoutAsync(string userId)
        {
            return Task.CompletedTask;
        }

        public async Task<User> RegisterAsync(RegisterViewModel registerViewModel)
        {
            var newUser = new User { UserName = registerViewModel.username, Email = registerViewModel.Email };
            var result = await _userManager.CreateAsync(newUser, registerViewModel.password);


            if (!result.Succeeded)
            {
                throw new ApplicationException("failed to register user");
            }

            return newUser;
        }
    }
}
