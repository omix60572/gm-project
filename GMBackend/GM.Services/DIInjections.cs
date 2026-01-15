using GM.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GM.Services;

public static class DIInjections
{
    public static IServiceCollection AddTokensService(this IServiceCollection services) =>
        services.AddSingleton<ITokenService, TokenService>();
}
