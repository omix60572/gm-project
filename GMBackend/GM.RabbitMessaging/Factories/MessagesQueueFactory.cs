using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories;

public class MessagesQueueFactory : IMessagesQueueFactory
{
    public IMessagesQueue CreateMessagesQueue(string queueName)
    {
        throw new NotImplementedException();
    }
}
