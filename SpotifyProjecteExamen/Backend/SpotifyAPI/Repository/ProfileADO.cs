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

    public static List<Profile> GetAll(SpotifyDBConnection dbConn)
    {
        List<Profile> profiles = new();

        dbConn.Open();
        string sql = "SELECT Id, Name, Description, State FROM Profiles";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            profiles.Add(new Profile
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                State = reader.GetString(3)
            });
        }

        dbConn.Close();
        return profiles;
    }



}