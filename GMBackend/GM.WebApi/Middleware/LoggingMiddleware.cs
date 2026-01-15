using Microsoft.AspNetCore.Http;
using NLog;
using System.Threading.Tasks;

namespace GM.WebApi.Middleware;

public class LoggingMiddleware
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private readonly RequestDelegate next;

    public LoggingMiddleware(RequestDelegate next) =>
        this.next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        this.logger.Trace("Logging middleware invoked");
        await this.next(context);
    }
}
