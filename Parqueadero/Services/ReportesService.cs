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

        public  ReporteVisitasDto ReporteVisitasPorCliente(long idCliente)
        {
            try
            {
                int cantidadVisitas = this._context.Calificaciones.Where(w => w.Visita.ClientId == idCliente).Count();
                ReporteVisitasDto reporte = this._context.Visita.Where(x => x.ClientId == idCliente).Select(x => new ReporteVisitasDto
                {
                    CantidadVisitas = cantidadVisitas,
                    Nombre = x.Client.Name,
                    PromedioCalificacion = this.PromedioCalificacion(idCliente),
                    Recaudo = x.Client.ValorHora * cantidadVisitas
                }).First();

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
                int resultado = this._context.Calificaciones.Where(w => w.Visita.ClientId == Id).Where(w => w.Calificacion != 0).Sum(s => s.Calificacion)
                            / this._context.Calificaciones.Where(w => w.Visita.ClientId == Id).Count();

                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
