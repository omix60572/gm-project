using GM.Remote.Enums;

namespace GM.Remote;

public class RemoteSearchSettings
{
    public const string Section = "RemoteModuleSettings";

    public ImageSearchProviders SearchProvider { get; set; }
    public string BaseUrl {  get; set; }
    public string APIKey { get; set; }
}
