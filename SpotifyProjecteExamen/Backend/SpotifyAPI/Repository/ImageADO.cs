using Microsoft.Data.SqlClient;
using SpotifyAPI.Services;
using SpotifyAPI.Model;
using SpotifyAPI.Utils;

namespace SpotifyAPI.Repository;

static class ImageADO

{

    public static void Insert(SpotifyDBConnection dbConn, Image image)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Images (Id, Url, Name, Description, Type)
                      VALUES (@Id, @Url, @Name, @Description, @Type)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", image.Id);
        cmd.Parameters.AddWithValue("@Url", image.Url);
        cmd.Parameters.AddWithValue("@Name", image.Name);
        cmd.Parameters.AddWithValue("@Description", image.Description);
        cmd.Parameters.AddWithValue("@Type", image.Type);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");

        dbConn.Close();
    }


    public static List<Image> GetAll(SpotifyDBConnection dbConn)
    {
        List<Image> images = new();

        dbConn.Open();
        string sql = "SELECT Id, Url, Name, Description, Type FROM Images";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            images.Add(new Image
            {
                Id = reader.GetGuid(0),
                Url = reader.GetString(1),
                Name = reader.GetString(2),
                Description = reader.GetString(3),
                Type = reader.GetString(4)
            });
        }

        dbConn.Close();
        return images;
    }

    public static void Update(SpotifyDBConnection dbConn, Image image)
    {
        dbConn.Open();

        string sql = @"UPDATE Images
                    SET Url = @Url,
                        Name = @Name,
                        Description = @Description,
                        Type = @Type
                    WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", image.Id);
        cmd.Parameters.AddWithValue("@Url", image.Url);
        cmd.Parameters.AddWithValue("@Name", image.Name);
        cmd.Parameters.AddWithValue("@Description", image.Description);
        cmd.Parameters.AddWithValue("@Type", image.Type);


        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"{rows} fila actualitzada.");

        dbConn.Close();
    }

}