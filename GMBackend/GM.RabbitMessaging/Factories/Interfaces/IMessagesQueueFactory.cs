using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories.Interfaces;

public interface IMessagesQueueFactory
{
    IMessagesQueue CreateMessagesQueue(string queueName);
}
