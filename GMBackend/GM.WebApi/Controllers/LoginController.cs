using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/auth")]
public class LoginController : BaseController
{
    private readonly UserManager<IdentityUser> userManager;

    public LoginController(UserManager<IdentityUser> userManager) =>
        this.userManager = userManager;



    //[HttpPost("login")]
    //public async Task<IActionResult> Login([FromBody] LoginRequest request)
}
