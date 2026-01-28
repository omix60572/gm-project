using GM.Remote.Enums;
using GM.Remote.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GM.Remote;

public static class DIInjections
{
    public static IServiceCollection AddRemoteSearchModule(this IServiceCollection services, IServiceProvider intermediateProvider)
    {
        var baseSettings =
            intermediateProvider.GetService<IOptions<RemoteSearchSettings>>()?.Value ??
            throw new ArgumentException("Remote search base settings is undefined");

        if (baseSettings.SearchProvider == ImageSearchProviders.None)
            return services;

        var googleSearchSettings = intermediateProvider.GetService<IOptions<GoogleSearchSettings>>()?.Value;
        if (googleSearchSettings != null)
            services.AddSingleton(googleSearchSettings);

        // TODO: Add remote search module

        return services;
    }

    public static IServiceCollection ConfigureRemoteSearchSettings(this IServiceCollection services, IConfiguration configuration) =>
        services
            .Configure<RemoteSearchSettings>(configuration.GetSection(RemoteSearchSettings.Section))
            .Configure<GoogleSearchSettings>(configuration.GetSection(GoogleSearchSettings.Section));
}
