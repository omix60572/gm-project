namespace GM.WebApi.Responses;

public class ApplicationTokenResponse
{
    public string ApplicationToken { get; set; }
    public uint ExpireHours { get; set; }
}
