using GM.RabbitMessaging.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace GM.RabbitMessaging.Base;

public abstract class QueueMessageBase
{
    protected BasicGetResult result;

    protected QueueMessageBase() => this.result = null;
    protected QueueMessageBase(BasicGetResult result) => this.result = result;

    public override string ToString()
    {
        var str = JsonConvert.SerializeObject(this);
        var queueMessage = new QueueMessage
        {
            ContentType = this.GetType(),
            Content = str
        };

        return JsonConvert.SerializeObject(queueMessage);
    }

    public object GetResult() => this.result;
}
