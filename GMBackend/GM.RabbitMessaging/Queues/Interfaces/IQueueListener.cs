namespace GM.RabbitMessaging.Queues.Interfaces;

public interface IQueueListener<T> where T : IQueueMessage
{
    Task ListenQueueAsync(Func<IQueueMessageHandler<T>> getHandler, IMessagesQueue queue, CancellationToken cancellationToken);
}
