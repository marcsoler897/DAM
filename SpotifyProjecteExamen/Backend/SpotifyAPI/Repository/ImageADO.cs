using Microsoft.Data.SqlClient;
using SpotifyAPI.Services;
using SpotifyAPI.Model;
using SpotifyAPI.Utils;

namespace SpotifyAPI.Repository;

static class ImageADO

{
    
    public static void Update(SpotifyDBConnection dbConn, User user)
    {
        user.Salt = Hash.GenerateSalt();
        user.Password = Hash.ComputeHash(user.Password, user.Salt);

        dbConn.Open();

        string sql = @"UPDATE Users
                    SET Username = @Username,
                        Email = @Email,
                        Password = @Password,
                        Salt = @Salt
                    WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", user.Id);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@Salt", user.Salt);


        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"{rows} fila actualitzada.");

        dbConn.Close();
    }

}