using GM.RabbitMessaging.Queues.Interfaces;
using Newtonsoft.Json;
using NLog;

namespace GM.RabbitMessaging.Queues;

public class QueueListener<T>(int waitDelay) : IQueueListener<T> where T: IQueueMessage
{
    private readonly int waitDelay = waitDelay;

    public async Task ListenQueueAsync(
        Func<IQueueMessageHandler<T>> getQueueHandler,
        IMessagesQueue queue,
        CancellationToken cancellation)
    {
        var messageQueueName = queue.QueueName;
        var logger = LogManager.GetLogger(messageQueueName);

        while (!cancellation.IsCancellationRequested)
        {
            var message = await queue.GetMessageAsync(cancellation);
            if (message == null)
            {
                await Task.Delay(waitDelay, cancellation);
                continue;
            }

            try
            {
                var receivedObject = JsonConvert.DeserializeObject<T>(message.GetAsString());
                var queueHandler = getQueueHandler();
                if (queueHandler != null)
                {
                    await queueHandler.HandleAsync(receivedObject, cancellation);
                }
                else
                {
                    logger.Error($"Failed to get queue handler for {messageQueueName}");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Failed to process message from queue {messageQueueName}");
                await Task.Delay(waitDelay,  cancellation);
            }
        }
    }
}
