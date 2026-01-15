using Microsoft.AspNetCore.Builder;

namespace GM.WebApi.Middleware.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseWebApiMiddleware(this IApplicationBuilder builder) =>
        builder
            .UseMiddleware<LoggingMiddleware>()
            .UseMiddleware<TokenValidationMiddleware>();
}
