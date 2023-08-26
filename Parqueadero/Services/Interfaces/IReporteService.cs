using Parqueadero.Data.Dto;

namespace Parqueadero.Services.Interfaces
{
    public interface IReporteService
    {

        List<ReporteVisitasDto> ReporteVisitasPorCliente(long idCliente);
         ReporteCalificacionDto ReporteCalificacion();
    }
}
