using Microsoft.AspNetCore.Mvc;

namespace Fringes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        //public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        //[HttpPost("register")]
        //public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User { UserName = registerViewModel.username, Email = registerViewModel.Email };
        //        var result = await _userManager.CreateAsync(user, registerViewModel.password);
        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return Ok(result);
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        //[Authorize]
        //[HttpPost("login")]
        //public async Task<IActionResult> login(LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return Ok();
        //        }

        //        ModelState.AddModelError(string.Empty, "Invalid login attempt");
        //        return BadRequest(ModelState);

        //    }
        //    return BadRequest(ModelState);
        //}






    }
}
