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