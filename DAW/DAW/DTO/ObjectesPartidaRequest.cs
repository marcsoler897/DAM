using DAW.Model;
using DAW.EndPoints;


namespace DAW.DTO;

public record ObjectesPartidaRequest(Guid idJugadorPartida, Guid idObjecte, int quant)
{
    public ObjectesPartida ToObjectesPartida(Guid idJugadorPartida)
    {
        
        return new ObjectesPartida
        {
            idJugadorPartida = idJugadorPartida,
            idObjecte = idObjecte,
            quant = quant
        };
    }
}