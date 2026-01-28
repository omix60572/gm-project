using GM.Services;
using GM.WebApi.Facades;
using GM.WebApi.Facades.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GM.WebApi;

public static class DIInjections
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IServiceProvider intermediateProvider) =>
        services
            .AddTokensService(intermediateProvider)
            .AddSingleton<ITokensFacade, TokensFacade>();
}
