namespace GM.RabbitMessaging.Providers.Interfaces;

public interface IMessagingSettingsProvider
{
    string GetConnectionString();
    string GetDefaultExchange();
    int GetListenerDelay();
}
