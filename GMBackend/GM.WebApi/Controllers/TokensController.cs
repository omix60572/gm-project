using GM.WebApi.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/tokens")]
public class TokensController : BaseController
{
    private readonly ITokensFacade tokensFacade;

    public TokensController(ITokensFacade tokensFacade) =>
        this.tokensFacade = tokensFacade;

    [HttpGet]
    [Route("get/{applicationName}")]
    public async Task<IActionResult> GetToken(string applicationName)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(this.tokensFacade.GetApplicationToken(applicationName));
    }


    [HttpPost]
    [Route("revoke/{applicationName}/{token}")]
    public async Task<IActionResult> RevokeToken(string applicationName, string token, CancellationToken cancellation)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(new { Success = await this.tokensFacade.RevokeTokenAsync(applicationName, token, cancellation) });
    }
}
