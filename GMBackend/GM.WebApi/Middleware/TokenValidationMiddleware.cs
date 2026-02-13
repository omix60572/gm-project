using System.Net;
using GM.WebApi.Facades.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GM.WebApi.Middleware;

public class TokenValidationMiddleware
{
    private readonly ITokensFacade tokensFacade;
    private readonly RequestDelegate next;

    private const int Unauthorized = (int)HttpStatusCode.Unauthorized;

    public TokenValidationMiddleware(RequestDelegate next, ITokensFacade tokensFacade)
    {
        this.tokensFacade = tokensFacade;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        var response = context.Response;

        if (request.Path.HasValue && request.Path.Value.StartsWith("/api/test/get") && request.Method == "GET")
        {
            await this.next(context);
            return;
        }

        var appNameHeader = request.Headers["ApplicationName"];
        if (appNameHeader.Count == 0 || string.IsNullOrEmpty(appNameHeader.ToString()))
        {
            response.StatusCode = Unauthorized;
            return;
        }

        var applicationName = appNameHeader.ToString();
        var isValidApplicationName = await this.tokensFacade.IsValidApplicationNameAsync(applicationName, context.RequestAborted);
        if (!isValidApplicationName)
        {
            response.StatusCode = Unauthorized;
            return;
        }

        if (request.Path.HasValue && request.Path.Value.StartsWith("/api/tokens/get/") && request.Method == "GET")
        {
            await this.next(context);
            return;
        }

        var authTokenHeader = request.Headers["ApplicationToken"];
        if (authTokenHeader.Count == 0 || string.IsNullOrEmpty(authTokenHeader.ToString()))
        {
            response.StatusCode = Unauthorized;
            return;
        }

        var isValidToken = await this.tokensFacade.ValidateTokenAsync(applicationName, authTokenHeader.ToString(), context.RequestAborted);
        if (!isValidToken)
        {
            response.StatusCode = Unauthorized;
            return;
        }

        await this.next(context);
    }
}
