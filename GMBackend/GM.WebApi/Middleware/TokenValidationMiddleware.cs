using GM.WebApi.Facades.Interfaces;
using Microsoft.AspNetCore.Http;
using NLog;

namespace GM.WebApi.Middleware;

public class TokenValidationMiddleware
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private readonly ITokensFacade tokensFacade;
    private readonly RequestDelegate next;

    public TokenValidationMiddleware(RequestDelegate next, ITokensFacade tokensFacade)
    {
        this.tokensFacade = tokensFacade;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // TODO: skip api: /api/tokens/get/{applicationName}

        this.logger.Trace("Token validation middleware invoked");
        await this.next(context);
    }
}
