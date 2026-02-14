namespace GM.Contracts.Models;

public class MovieModel
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public short ReleaseYear { get; set; }
    public string SourceUrl { get; set; }
}
