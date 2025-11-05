using SpotifyAPI.Repository;
using SpotifyAPI.Services;
using SpotifyAPI.Model;

namespace SpotifyAPI.EndPoints;

public static class ImageEndpoints
{


    public static void MapImageEndpoints(this WebApplication app, SpotifyDBConnection dbConn)
    {


        app.MapPost("/images", (ImageRequest req) =>
        {
            Image image = new Image
            {
                Id = Guid.NewGuid(),
                Url = req.Url,
                Name = req.Name,
                Description = req.Description,
                Type = req.Type
            };
            ImageADO.Insert(dbConn, image);
            return Results.Created($"/images/{image.Id}", image);
        });


        app.MapPut("/images/{id}", (Guid id, ImageRequest req) =>
        {
            // Image? existing = ImageADO.GetById(dbConn, id);

            // if (existing == null)
            // {
            //     return Results.NotFound();
            // }

            Image updated = new Image
            {
                Id = id,
                Url = req.Url,
                Name = req.Name,
                Description = req.Description,
                Type = req.Type
            };

            ImageADO.Update(dbConn, updated);

            return Results.Ok(updated);
        });


    }
}

public record ImageRequest(string Url, string Name, string Description, string Type);