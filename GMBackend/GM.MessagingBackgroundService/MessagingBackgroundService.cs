using GM.RabbitMessaging.Contracts;
using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Queues.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GM.MessagingBackgroundService;

public class MessagingBackgroundService(
    IServiceProvider serviceProvider,
    IListenersFactory listenersFactory,
    IMessagesQueueFactory messagesQueueFactory) : BackgroundService
{
    private readonly IServiceProvider serviceProvider = serviceProvider;
    private readonly IListenersFactory listenersFactory = listenersFactory;
    private readonly IMessagesQueueFactory messagesQueueFactory = messagesQueueFactory;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IQueueMessageHandler<T> getQueueHandler<T>() where T : IQueueMessage =>
            serviceProvider.GetRequiredService<IQueueMessageHandler<T>>();

        Task.Factory.StartNew(async () =>
        {
            var testListener = this.listenersFactory.GetListener<TestRabbitQueue>();
            var testQueue = this.messagesQueueFactory.GetMessagesQueue(typeof(TestRabbitQueue).FullName);
            await testListener.ListenQueueAsync(() => getQueueHandler<TestRabbitQueue>(), testQueue, stoppingToken);
        }, stoppingToken);

        return Task.CompletedTask;
    }
}
