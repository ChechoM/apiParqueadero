using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Dto;
using Parqueadero.Data.Models;
using Parqueadero.Services.Interfaces;

namespace Parqueadero.Services
{
    public class CalificacionesService : ICalificacionesService
    {
        public PqDBContext _context;
        public CalificacionesService(PqDBContext context) 
        {
            _context = context;
        }

        public Calificaciones ModelToDto(CalificacionesDto calificacionesDto)
        {
            Calificaciones calificaciones = new Calificaciones()
            {
                Calificacion = calificacionesDto.Calificacion,
                Comentario = calificacionesDto.Comentario,
                IdVisita = calificacionesDto.IdVisita,
                Visita = _context.Visita.Where(x => x.Id == calificacionesDto.IdVisita).FirstOrDefault()
            };

            return calificaciones;

        }

        public async Task<ActionResult<IEnumerable<Calificaciones>>> GetCalificacionesPorcliente(long id)
        {
            var query = await _context.Calificaciones.Where(x=> x.Visita.Client.Id == id).Include(x=> x.Visita).ToListAsync();

            return query;
        }
    }
}
