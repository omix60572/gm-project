using GM.RabbitMessaging.Providers.Interfaces;

namespace GM.RabbitMessaging.Providers;

public class MessagingSettingsProvider : IMessagingSettingsProvider
{
    private readonly MessagingSettings settings;

    public MessagingSettingsProvider(MessagingSettings settings) =>
        this.settings = settings;

    public string GetConnectionString() =>
        this.settings.ConnectionString;

    public string GetDefaultExchange() =>
        this.settings.DefaultExchange;

    public int GetListenerDelay() =>
        this.settings.QueueListenerDelay;
}
