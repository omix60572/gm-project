using GM.Remote.Enums;

namespace GM.RemoteSearch.Settings;

public class RemoteSearchSettings
{
    public const string Section = "RemoteSearchSettings";

    public ImageSearchProviders SearchProvider { get; set; }
}
