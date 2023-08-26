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
                    int promedio = PromedioCalificacion(item.Id);
                                        
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
                    CantidadVisitas = this._context.Visita.Where(w => w.ClientId == x.Id).Count(),
                    Nombre = x.Name,
                    PromedioCalificacion = this.PromedioCalificacion(x.Id),
                    Recaudo = Convert.ToInt32(x.ValorHora * (this._context.Visita.Where(w => w.ClientId == x.Id).Count()))

                }).ToList();

                return reporte;
            }
            catch (Exception ex)
            {                
                return null;
            }
            
        }

        public int PromedioCalificacion(long Id)
        {
            try
            {
                long idVisita = this._context.Visita.Where(x => x.ClientId == Id).Select(x => x.Id).FirstOrDefault();
                int resultado = this._context.Calificaciones.Where(w => w.IdVisita == idVisita).Where(w => w.Calificacion != 0).Sum(s => s.Calificacion)
                            / this._context.Calificaciones.Where(w => w.IdVisita == idVisita).Count();

                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
