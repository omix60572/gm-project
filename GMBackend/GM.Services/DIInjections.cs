using GM.Services.Interfaces;
using GM.Services.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GM.Services;

public static class DIInjections
{
    public static IServiceCollection AddTokensService(this IServiceCollection services, IServiceProvider intermediateProvider)
    {
        var jwtSettings =
            intermediateProvider.GetService<IOptions<JwtSettings>>()?.Value ??
            throw new ArgumentException("Web API JWT settings is undefined");

        services
            .AddSingleton(jwtSettings)
            .AddSingleton<ITokensService, TokenService>();

        return services;
    }

    public static IServiceCollection ConfigureServicesSettings(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
}
