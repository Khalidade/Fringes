using Fringes.Models;

namespace Fringes.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterViewModel registerViewModel);
        Task<User> loginAsync(LoginViewModel loginViewModel);
        Task LogoutAsync(string userId);
        Task<User> GetUserAsync(string username);
    }
}
