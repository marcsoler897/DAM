using SpotifyAPI.Repository;
using SpotifyAPI.Services;
using SpotifyAPI.Model;
using System.Data.Common;

namespace SpotifyAPI.EndPoints;

public static class ProfileEndpoints
{

    public static void MapProfileEndpoints(this WebApplication app, SpotifyDBConnection dbConn)
    {
        // POST /playlists
        app.MapPost("/profiles", (ProfileRequest req) =>
        {
            Profile profile = new Profile
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                Description = req.Description,
                State = req.State
            };
            ProfileADO.Insert(dbConn, profile);
            return Results.Created($"/profiles/{profile.Id}", profile);
        });

        app.MapGet("/profiles", () =>
        {
            List<Profile> profiles = ProfileADO.GetAll(dbConn);
            return Results.Ok(profiles);
        });

    }


    
}

public record ProfileRequest(string Name, string Description, string State);