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
        var stopwatch = Stopwatch.StartNew();

        this.logger.Trace($"Incoming request: {request.Method} {request.Path}");

        await this.next(context);

        stopwatch.Stop();
        var response = context.Response;

        this.logger.Info($"Request {request.Method} {request.Path}, responded {response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms | UserAgent: {request.Headers.UserAgent}");
    }
}
