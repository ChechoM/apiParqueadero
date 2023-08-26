using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Dto;
using Parqueadero.Data.Models;
using Parqueadero.Services.Interfaces;

namespace Parqueadero.Services
{
    public class ReportesService: IReporteService
    {
        private readonly PqDBContext _context;
        public ReportesService(PqDBContext context) 
        {
            _context = context;
        }

        public  ReporteCalificacionDto ReporteCalificacion()
        {
            try
            {                

                List<string> AltaAux  = new List<string>(); ;
                List<string> MediaAux =  new List<string>(); ;
                List<string> BajaAux  = new List<string>(); ;

                List<Client> ListaClientes = this._context.Client.Select(x=> x).ToList();

                foreach (var item in ListaClientes)
                {
                    int promedio = this._context.Calificaciones.Where(w => w.Visita.ClientId == item.Id).Sum(s => s.Calificacion) / this._context.Calificaciones.Where(w => w.Visita.ClientId == item.Id).Count();
                                        
                    if (promedio ==5 || promedio  > 3)
                    {
                        AltaAux.Add(item.Name);
                    }
                    if (promedio ==  3)
                    {
                        MediaAux.Add(item.Name);
                    }
                    if (promedio < 3)
                    {
                        BajaAux.Add(item.Name);
                    }
                }

                ReporteCalificacionDto reporteCalificacionDto = new ReporteCalificacionDto()
                {
                    Alta = AltaAux,
                    Media = MediaAux,
                    Baja = BajaAux
                };

                return reporteCalificacionDto;
            }
            catch (Exception ex)
            {
               return null;
            }
             
        }       

        public  List<ReporteVisitasDto> ReporteVisitasPorCliente(long idUser)
        {
            try
            {

                List<ReporteVisitasDto> reporte = this._context.Client.Where(x => x.UserId == idUser).Select(x => new ReporteVisitasDto
                {
                    id = x.Id,
                    CantidadVisitas = this._context.Visita.Where(w => w.ClientId == x.Id).Count(),
                    Nombre = x.Name,
                    PromedioCalificacion = this._context.Calificaciones.Where(w=> w.Visita.ClientId == x.Id).Sum(s=> s.Calificacion) / this._context.Calificaciones.Where(w => w.Visita.ClientId == x.Id).Count(),
                    Recaudo = Convert.ToInt32(x.ValorHora * (this._context.Visita.Where(w => w.ClientId == x.Id).Count()))

                }).ToList();

                return reporte;
            }
            catch (Exception ex)
            {                
                return null;
            }
            
        }
    }
}
