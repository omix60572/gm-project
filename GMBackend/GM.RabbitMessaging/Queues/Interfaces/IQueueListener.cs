namespace GM.RabbitMessaging.Queues.Interfaces;

public interface IQueueListener<T> where T : IQueueMessage
{
    Task ListenQueueAsync(Func<IQueueMessageHandler<T>> getQueueHandler, IMessagesQueue queue, CancellationToken cancellation);
}
