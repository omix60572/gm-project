using GM.CommandHandlers;
using GM.QueryHandlers;
using GM.Remote;
using GM.Sql;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Hosting;

namespace GM.Statup;

public static class Program
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public static async Task Main()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddEnvironmentVariables();

        var configuration = configurationBuilder
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = GetWebHostBuilder(configuration);
        try
        {
            await builder.Build().RunAsync();
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, "Error running API Backend. Try running as a console app to see error details.");
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
                services.Configure<SqlSettings>(configuration.GetSection(SqlSettings.Section));
                services.Configure<RemoteSearchSettings>(configuration.GetSection(RemoteSearchSettings.Section));

                var intermediateProvider = services.BuildServiceProvider();

                var sqlSettings =
                    intermediateProvider.GetService<IOptions<SqlSettings>>()?.Value ??
                    throw new ArgumentException("Sql settings is undefined");

                var remoteModuleSettings =
                    intermediateProvider.GetService<IOptions<RemoteSearchSettings>>()?.Value ??
                    throw new ArgumentException("Remote module settings is undefined");

                services
                    .AddSingleton(sqlSettings)
                    .AddSingleton(remoteModuleSettings)
                    .AddSql()
                    .AddQueryHandlers()
                    .AddCommandHandlers()
                    .AddRemoteModule();
            })
            .UseNLog();
    }
}
