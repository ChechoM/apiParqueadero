using Microsoft.AspNetCore.Mvc;
using Parqueadero.Data.Dto;
using Parqueadero.Data.Models;

namespace Parqueadero.Services.Interfaces
{
    public interface ICalificacionesService
    {
        public Calificaciones ModelToDto(CalificacionesDto calificacionesDto);
        public Task<ActionResult<IEnumerable<Calificaciones>>> GetCalificacionesPorcliente(long id);
    }
}
