using GM.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System.Net;

namespace GM.WebApi.Middleware;

public class ExceptionLoggingMiddleware
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private readonly RequestDelegate next;

    private const string ExceptionMessage = "Web API request exception thrown";

    public ExceptionLoggingMiddleware(RequestDelegate next) =>
        this.next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        var fullRequestPath = $"{request.Path.Value}{request.QueryString}";

        try
        {
            await this.next(context);
        }
        catch (Exception ex)
        {
            var statusCode = context.Response.StatusCode.ToString();
            this.logger
                .WithProperty(LoggingFields.Http.StatusCode, statusCode)
                .WithProperty(LoggingFields.Http.RequestPath, fullRequestPath)
                .WithProperty(LoggingFields.Http.Method, request.Method)
                .Error(ex, ExceptionMessage);

            // TODO: https://dev.to/farrukh_rehman/lesson-13a-centralized-error-handling-validation-backend-29ip
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
            ArgumentException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        context.Response.StatusCode = statusCode;

        var response = new
        {
            StatusCode = statusCode,
            Message = ExceptionMessage
        };

        var jsonResponse = JsonConvert.SerializeObject(response);
        return context.Response.WriteAsync(jsonResponse);
    }
}
