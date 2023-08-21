using Parqueadero.Data.Dto;

namespace Parqueadero.Services.Interfaces
{
    public interface IReporteService
    {

         ReporteVisitasDto ReporteVisitasPorCliente(long idCliente);
         ReporteCalificacionDto ReporteCalificacion();
    }
}
