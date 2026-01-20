using GM.MessagingHandlers;
using GM.RabbitMessaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Hosting;

namespace GM.MessagingBackgroundService;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var logger = LogManager.GetCurrentClassLogger();
        try
        {
            logger.Trace("Starting messaging backend application...");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = GetHostBuilder(configuration, args);
            await builder.Build().RunAsync();
        }
        catch (Exception ex)
        {
            logger.Fatal(ex, "Error running messaging backend service application");
        }
    }

    private static IHostBuilder GetHostBuilder(IConfiguration configuration, string[] args)
    {
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.Configure<MessagingSettings>(configuration.GetSection(MessagingSettings.Section));

                var intermediateProvider = services.BuildServiceProvider();
                services
                    .AddRabbitMessaging(intermediateProvider.GetService<IOptions<MessagingSettings>>()?.Value)
                    .AddMessagingHandlers()
                    .AddHostedService<MessagingBackgroundService>();
            })
            .UseNLog();
    }
}
