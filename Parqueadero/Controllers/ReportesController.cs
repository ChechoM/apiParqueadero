using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Dto;
using Parqueadero.Services;
using Parqueadero.Services.Interfaces;

namespace Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : Controller
    {

        private readonly IReporteService _ReporteService;
        public ReportesController(PqDBContext context, IReporteService reporteService)
        {

            _ReporteService = reporteService;

        }

        // GET: api/Clients/ReporteCalificacion
        [HttpGet("ReporteCalificacion")]
        public async Task<ActionResult<ReporteCalificacionDto>> ReporteCalificacion()
        {
            var respuesta = _ReporteService.ReporteCalificacion();
            if (respuesta == null)
            {
                return Problem("Tenemos problemas con la aplicacion comuniquese con el fabricante.");
            }
            return respuesta;
        }

        // GET: api/Clients/ReporteVisitasPorCliente
        [HttpPost("ReporteVisitasPorUsuario")]
        public async Task<ActionResult<List<ReporteVisitasDto>>> ReporteVisitasPorUsuario(int id)
        {
            var respuesta = _ReporteService.ReporteVisitasPorCliente(id);
            if (respuesta == null)
            {
                return Problem("Error en la consulta reporte visitas por cliente verifique los datos ingresados.");
            }

            return respuesta;
        }
    }
}
