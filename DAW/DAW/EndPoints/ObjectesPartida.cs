using DAW.Services;
using DAW.Model;
using DAW.Repository;
using DAW.DTO;

namespace DAW.EndPoints;

public static class ObjectesPartidaEndpoints
{
    public static void MapObjectesPartidaEndpoints(this WebApplication app, DAWDBConnection dbConn)
    {
        app.MapPost("/objectesPartida/{idObjecte}/jugadorpartida/{idJugadorPartida}", (ObjectesPartidaRequest req) =>
        {
            ObjectesPartida objPar = new ObjectesPartida
            {
                idJugadorPartida = req.idJugadorPartida,
                idObjecte = req.idObjecte,
                quant = req.quant
            };

    ObjectesPartidaADO.Insert(dbConn, objPar);
            return Results.Created($"/objectesPartida/{objPar.idObjecte}/jugadorPartida{objPar.idJugadorPartida}" , objPar);
        });
    }
}