using GM.Logging;
using Microsoft.AspNetCore.Http;
using NLog;
using System.Diagnostics;

namespace GM.WebApi.Middleware;

public class LoggingMiddleware
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private readonly RequestDelegate next;

    public LoggingMiddleware(RequestDelegate next) =>
        this.next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        var fullRequestPath = $"{request.Path.Value}{request.QueryString}";
        var stopwatch = Stopwatch.StartNew();

        // TODO: Исправить, не работает
        var properties = new Dictionary<string, string>
        {
            { LoggingFields.Http.RequestPath, fullRequestPath },
            { LoggingFields.Http.Method, request.Method }
        };

        using var _ = ScopeContext.PushProperties(properties);

        this.logger.Trace($"Incoming request: {request.Method} {request.Path}");
        await this.next(context);

        stopwatch.Stop();
        var response = context.Response;

        this.logger.Info($"Request {request.Method} {fullRequestPath}, responded {response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms | UserAgent: {request.Headers.UserAgent}");
    }
}
