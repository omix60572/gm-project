using GM.CommandHandlers;
using GM.QueryHandlers;
using GM.RemoteSearch;
using GM.Services;
using GM.Sql;
using GM.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Hosting;

namespace GM.WebApiStartup;

public static class Program
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public static async Task Main()
    {
        try
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddEnvironmentVariables();

            var configuration = configurationBuilder
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = GetWebHostBuilder(configuration);
            await builder.Build().RunAsync();
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, "Error running web API backend. Try running as a console app to see error details.");
        }
    }

    private static IHostBuilder GetWebHostBuilder(IConfiguration configuration)
    {
        return Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder
                    .UseConfiguration(configuration)
                    .UseKestrel()
                    .UseContentRoot(Path.GetDirectoryName(Environment.ProcessPath))
                    .UseStartup<Startup>();
            })
            .ConfigureServices((_, services) =>
            {
                services
                    .ConfigureSqlSettings(configuration)
                    .ConfigureServicesSettings(configuration)
                    .ConfigureRemoteSearchSettings(configuration);

                var intermediateProvider = services.BuildServiceProvider();

                var sqlSettings =
                    intermediateProvider.GetService<IOptions<SqlSettings>>()?.Value ??
                    throw new ArgumentException("Sql settings is undefined");

                services
                    .AddSql(sqlSettings)
                    .AddQueryHandlers()
                    .AddCommandHandlers()
                    .AddWebApi(intermediateProvider)
                    .AddRemoteSearchModule(intermediateProvider);
            })
            .UseNLog();
    }
}
