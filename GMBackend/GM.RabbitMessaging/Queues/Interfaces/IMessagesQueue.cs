namespace GM.RabbitMessaging.Queues.Interfaces;

public interface IMessagesQueue
{
    Task<IQueueMessage> GetMessageAsync(CancellationToken cancellationToken);
    Task SendMessageAsync(IQueueMessage message, CancellationToken cancellationToken);
}
