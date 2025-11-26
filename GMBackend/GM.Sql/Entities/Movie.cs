namespace GM.Sql.Entities;

public class Movie
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ushort ReleaseYear { get; set; }
    public string SourceUrl { get; set; }
}
