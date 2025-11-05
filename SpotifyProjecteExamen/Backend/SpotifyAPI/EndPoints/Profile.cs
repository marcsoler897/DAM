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

        app.MapGet("/profiles/{id}", (Guid id) =>
        {
            Profile? profile = ProfileADO.GetById(dbConn, id);

            return profile is not null
                ? Results.Ok(profile)
                : Results.NotFound(new { message = $"Profile with Id {id} not found." });
        });

    }


    
}

public record ProfileRequest(string Name, string Description, string State);