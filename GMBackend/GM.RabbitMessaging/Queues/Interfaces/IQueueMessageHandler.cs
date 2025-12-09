namespace GM.RabbitMessaging.Queues.Interfaces;

public interface IQueueMessageHandler<in T> where T : IQueueMessage
{
    Task HandleAsync(T message, CancellationToken cancellation);
}
