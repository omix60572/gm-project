using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories.Interfaces;

public interface IMessagesQueueFactory
{
    IMessagesQueue GetMessagesQueue(string queueName);
}
