namespace GM.RabbitMessaging.Queues.Interfaces;

public interface IMessagesQueue
{
    string QueueName { get; }

    Task<IQueueMessage> GetMessageAsync(CancellationToken cancellation);
    Task SendMessageAsync(IQueueMessage message, CancellationToken cancellation);
}
