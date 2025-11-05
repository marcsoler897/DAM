using System.Reflection.Metadata.Ecma335;

namespace SpotifyAPI.Model;

public class Image
{
    public Guid Id { get; set; }
    public string Url { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; }
    public string Type { get; set; } = "";
}