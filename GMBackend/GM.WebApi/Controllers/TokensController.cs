using GM.WebApi.Facades.Interfaces;
using GM.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/tokens")]
public class TokensController : ControllerBase
{
    private readonly ITokensFacade tokensFacade;

    public TokensController(ITokensFacade tokensFacade) =>
        this.tokensFacade = tokensFacade;

    [HttpGet]
    [Route("get/{applicationName}")]
    public async Task<IActionResult> GetToken(string applicationName, CancellationToken cancellation)
    {
        if (string.IsNullOrEmpty(applicationName))
            return BadRequest();

        if (await this.tokensFacade.IsValidApplicationNameAsync(applicationName, cancellation))
            return Unauthorized();

        var applicationToken = this.tokensFacade.GetApplicationToken(applicationName);
        return Ok(new ApplicationTokenResponse { ApplicationToken = applicationToken });
    }

    // TODO: Revoke tokens API
}
