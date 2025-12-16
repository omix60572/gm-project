using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GM.RabbitMessaging.Base;

public abstract class QueueMessageBase
{
    protected BasicGetResult getResult;
    protected string body;

    protected QueueMessageBase()
    {
        this.getResult = null;
        this.body = null;
    }

    protected QueueMessageBase(BasicGetResult getResult) => this.getResult = getResult;

    protected QueueMessageBase(string body) => this.body = body;

    public string GetAsString() =>
        this.getResult != null ? Encoding.UTF8.GetString(this.getResult.Body.ToArray()) : this.body;

    public override string ToString()
    {
        var str = JsonConvert.SerializeObject(this);
        var queueMessage = new
        {
            ContentType = this.GetType(),
            Content = str
        };

        return JsonConvert.SerializeObject(queueMessage);
    }

    public BasicGetResult GetResult() => this.getResult;
}
