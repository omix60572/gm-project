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
    public async Task<IActionResult> GetToken(string applicationName) =>
        Ok(this.tokensFacade.GetApplicationToken(applicationName));
    

    [HttpPost]
    [Route("revoke/{applicationName}/{token}")]
    public async Task<IActionResult> RevokeToken(string applicationName, string token, CancellationToken cancellation) =>
        Ok(new { Success = await this.tokensFacade.RevokeTokenAsync(applicationName, token, cancellation) });
}
