using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Queues;

public class QueueListener<T>(MessagingSettings settings) : IQueueListener<T> where T: IQueueMessage
{
    private readonly MessagingSettings settings = settings;

    public async Task ListenQueueAsync(Func<IQueueMessageHandler<T>> getHandler, IMessagesQueue queue, CancellationToken cancellationToken)
    {

    }
}
