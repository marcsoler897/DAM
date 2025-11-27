using DAW.Services;
using DAW.EndPoints;
using DAW.Model;
using Microsoft.Data.SqlClient;
using DAW.DTO;

namespace DAW.Repository;

static class ObjectesPartidaADO
{
    public static void Insert(DAWDBConnection dbConn, ObjectesPartida objectesPartida)
    {

        dbConn.Open();

        string sql = @"INSERT INTO ObjectesPartida (idJugadorPartida, idObjecte, quant)
                      VALUES (@idJugadorPartida, idObjecte, @quant)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@idJugadorPartida", objectesPartida.idJugadorPartida);
        cmd.Parameters.AddWithValue("@idObjecte", objectesPartida.idObjecte);
        cmd.Parameters.AddWithValue("@quant", objectesPartida.quant);

        // int rows = cmd.ExecuteNonQuery();
        // Console.WriteLine($"{rows} fila inserida.");

        dbConn.Close();
    }
}