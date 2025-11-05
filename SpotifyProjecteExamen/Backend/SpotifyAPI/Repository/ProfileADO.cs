using Microsoft.Data.SqlClient;
using SpotifyAPI.Services;
using SpotifyAPI.Model;
using SpotifyAPI.Utils;

namespace SpotifyAPI.Repository;

static class ProfileADO

{
    public static void Insert(SpotifyDBConnection dbConn, Profile profile)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Profiles (Id, Name, Description, State)
                      VALUES (@Id, @Name, @Description, @State)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", profile.Id);
        cmd.Parameters.AddWithValue("@Name", profile.Name);
        cmd.Parameters.AddWithValue("@Description", profile.Description);
        cmd.Parameters.AddWithValue("@State", profile.State);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");

        dbConn.Close();
    }



}