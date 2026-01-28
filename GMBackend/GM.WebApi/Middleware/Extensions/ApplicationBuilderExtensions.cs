using Microsoft.AspNetCore.Builder;

namespace GM.WebApi.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseWebApiMiddleware(this IApplicationBuilder builder) =>
        builder
            .UseMiddleware<ExceptionLoggingMiddleware>()
            .UseMiddleware<LoggingMiddleware>()
            .UseMiddleware<TokenValidationMiddleware>();
}
