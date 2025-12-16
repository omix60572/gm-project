using GM.MessagingHandlers.Handlers;
using GM.RabbitMessaging.Contracts;
using GM.RabbitMessaging.Queues.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GM.MessagingHandlers;

public static class DIInjections
{
    public static IServiceCollection AddMessagingHandlers(this IServiceCollection services) =>
        services.AddTransient<IQueueMessageHandler<TestRabbitQueue>, TestRabbitQueueHandler>();
}
