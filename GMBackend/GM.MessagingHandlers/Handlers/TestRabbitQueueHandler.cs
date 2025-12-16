using GM.RabbitMessaging.Contracts;
using GM.RabbitMessaging.Queues.Interfaces;
using NLog;

namespace GM.MessagingHandlers.Handlers;

public class TestRabbitQueueHandler : IQueueMessageHandler<TestRabbitQueue>
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public Task HandleAsync(TestRabbitQueue message, CancellationToken cancellation)
    {
        this.logger.Trace("Test message received...");
        return Task.CompletedTask;
    }
}
