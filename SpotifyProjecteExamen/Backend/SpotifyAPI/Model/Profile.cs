namespace SpotifyAPI.Model;

public class Profile
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; }
    public string State { get; set; } = "";
}