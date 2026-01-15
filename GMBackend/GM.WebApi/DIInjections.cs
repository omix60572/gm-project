using GM.Services;
using GM.Services.Settings;
using GM.WebApi.Facades;
using GM.WebApi.Facades.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GM.WebApi;

public static class DIInjections
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, JwtSettings jwtSettings) =>
        services
            .AddSingleton(jwtSettings)
            .AddSingleton<ITokensFacade, TokensFacade>()
            .AddTokensService();
}
